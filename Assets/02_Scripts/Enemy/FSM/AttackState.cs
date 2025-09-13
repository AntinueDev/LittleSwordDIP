using LittleSword.Player;
using UnityEngine;
using Logger = LittleSword.Common.Logger;

namespace LittleSword.Enemy.FSM
{
    public class AttackState : IState
    {
        private readonly float attackCooldown;
        private float lastAttackTime;

        public AttackState(float attackCooldown = 1.0f)
        {
            this.attackCooldown = attackCooldown;
            lastAttackTime = Time.time - this.attackCooldown;
        }
        
        public void Enter(Enemy enemy)
        {
            Logger.Log("공격 진입");
        }

        public void Update(Enemy enemy)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                lastAttackTime = Time.time;
                
                // 타겟에 없거나 사망했을 때 Idle 상태로 전환
                if (enemy.target == null || enemy.target.GetComponent<BasePlayer>()?.IsDead == true)
                {
                    enemy.ChangeState<IdleState>();
                    return;
                }

                if (enemy.IsInAttackRange())
                {
                    enemy.animator.SetBool(Enemy.hashIsRun, false);
                    enemy.animator.SetTrigger(Enemy.hashAttack);
                }
                else
                {
                    enemy.ChangeState<ChaseState>();
                }
            }
        }

        public void Exit(Enemy enemy)
        {
            Logger.Log("공격 종료");
        }
    }
}