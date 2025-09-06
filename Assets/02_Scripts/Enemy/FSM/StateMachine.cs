using System;
using System.Collections.Generic;
using UnityEngine;

namespace LittleSword.Enemy.FSM
{
    public class StateMachine
    {
        private Enemy enemy;
        // 생성자
        public StateMachine(Enemy enemy)
        {
            this.enemy = enemy;
        }
        
        // 현재 상태 저장 변수
        private IState currentState;
        
        // 상태 전환 메서드
        public void ChangeState(IState newState)
        {
            currentState?.Exit(enemy);
            currentState = newState;
            currentState.Enter(enemy);
        }
        
        // 상태 갱신 메서드 (일반 메소드)
        public void Update()
        {
            currentState?.Update(enemy);
        }
    }
}