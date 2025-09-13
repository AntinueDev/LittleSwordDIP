using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LittleSword.Enemy.FSM;

namespace LittleSword.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public static readonly int hashIsRun = Animator.StringToHash("IsRun");
        public static readonly int hashAttack = Animator.StringToHash("Attack");

        // Enemy State
        [SerializeField] private EnemyStats enemyStats;

        // 추적 대상
        [SerializeField] private Transform target;
        [SerializeField] private LayerMask playerLayer;

        // 상태 머신
        private StateMachine stateMachine;

        // 상태를 저장할 딕셔너리 생성
        private Dictionary<Type, IState> states;
        
        // 컴포넌트 캐싱
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;

        public void ChangeState<T>() where T : IState
        {
            // 딕셔너리에서 상태 검색 및 추출
            if (states.TryGetValue(typeof(T), out IState newState))
            {
                stateMachine.ChangeState(newState);
            }
        }

        // 주인공 검출 로직
        public bool DetectPlayer()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, enemyStats.chaseRange, playerLayer);
            if (colliders.Length > 0)
            {
                target = colliders
                    .OrderBy(c => (transform.position - c.transform.position).sqrMagnitude)
                    .First()
                    .transform;
                return true;
            }

            target = null;
            return false;
        }
        
        // 추적 로직 (이동 로직)
        public void MoveToPlayer()
        {
            if (target == null) return;
            // 추적 방향 벡터 계산
            Vector2 direction = (target.position - transform.position).normalized;
            spriteRenderer.flipX = direction.x < 0;
            rb.linearVelocity = direction * enemyStats.moveSpeed;
        }

        public void StopMoving()
        {
            rb.linearVelocity = Vector2.zero;
        }
        
        // 공격 사정거리 체크
        public bool IsInAttackRange()
        {
            if (target == null) return false;
            float distance = (transform.position - target.position).sqrMagnitude;
            return distance <= enemyStats.attackRange * enemyStats.attackRange;
        }

        #region 유니티 이벤트

        private void Awake()
        {
            states = new Dictionary<Type, IState>
            {
                // Indexer 방식
                [typeof(IdleState)] = new IdleState(enemyStats.detectInterval),
                [typeof(ChaseState)] = new ChaseState(enemyStats.detectInterval),
                [typeof(AttackState)] = new AttackState(),
            };
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            stateMachine = new StateMachine(this);
            // 초기 상태 설정(IdleState)
            ChangeState<IdleState>();
        }

        private void Update()
        {
            stateMachine.Update();
        }

        #endregion

        #region Gizmos

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, enemyStats.chaseRange);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, enemyStats.attackRange);
        }

        #endregion
    }
}