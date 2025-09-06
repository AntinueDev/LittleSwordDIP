using System;
using System.Collections.Generic;
using UnityEngine;
using LittleSword.Enemy.FSM;

namespace LittleSword.Enemy
{
    public class Enemy : MonoBehaviour
    {
        // 상태 머신
        private StateMachine stateMachine;

        // 상태를 저장할 딕셔너리 생성
        private Dictionary<Type, IState> states = new Dictionary<Type, IState>
        {
            // Indexer 방식
            [typeof(IdleState)] = new IdleState(),
            [typeof(ChaseState)] = new ChaseState(),
            [typeof(AttackState)] = new AttackState(),
        };        
        
        public void ChangeState<T>() where T : IState
        {
            // 딕셔너리에서 상태 검색 및 추출
            if (states.TryGetValue(typeof(T), out IState newState))
            {
                stateMachine.ChangeState(newState);
            }
        }

        #region 유니티 이벤트

        private void Start()
        {
            stateMachine = new StateMachine(this);
            // 초기 상태 설정(IdleState)
            ChangeState<IdleState>();
        }

        private void Update()
        {
            stateMachine.Update();
        }

        #endregion
    }
}