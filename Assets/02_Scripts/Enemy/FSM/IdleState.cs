using UnityEngine;
using Logger = LittleSword.Common.Logger;

namespace LittleSword.Enemy.FSM
{
    public class IdleState : IState
    {
        private readonly float detectInterval;
        private float lastDetectTime;
        
        // 생성자 
        public IdleState(float detectInterval = 0.5f)
        {
            this.detectInterval = detectInterval;
            lastDetectTime = Time.time - detectInterval;
        }
        
        public void Enter(Enemy enemy)
        {
            enemy.animator.SetBool(Enemy.hashIsRun, false);
        }

        public void Update(Enemy enemy)
        {
            if (Time.time - lastDetectTime >= detectInterval)
            {
                lastDetectTime = Time.time;
                if (enemy.DetectPlayer())
                {
                    enemy.ChangeState<ChaseState>();
                }
            }
        }

        public void Exit(Enemy enemy)
        {
            Logger.Log("Idle 종료");
        }
    }
}