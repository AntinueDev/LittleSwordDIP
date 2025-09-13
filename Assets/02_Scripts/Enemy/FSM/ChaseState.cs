using UnityEngine;
using Logger = LittleSword.Common.Logger;

namespace LittleSword.Enemy.FSM
{
    public class ChaseState : IState
    {
        private readonly float detectInterval;
        private float lastDetectTime;

        public ChaseState(float detectInterval)
        {
            this.detectInterval = detectInterval;
            lastDetectTime = Time.time - detectInterval;
        }

        public void Enter(Enemy enemy)
        {
            Logger.Log("Chase 진입");
        }

        public void Update(Enemy enemy)
        {
            if (Time.time - lastDetectTime > detectInterval)
            {
                lastDetectTime = Time.time;
                if (enemy.DetectPlayer())
                {
                    enemy.MoveToPlayer();
                    
                    // 주인공이 공격 사정거리 이내일 경우 공격 상태로 전환
                    if (enemy.IsInAttackRange())
                    {
                        enemy.StopMoving();
                        enemy.ChangeState<AttackState>();
                    }
                }
                else
                {
                    enemy.StopMoving();
                    enemy.ChangeState<IdleState>();
                }
            }
        }

        public void Exit(Enemy enemy)
        {
            Logger.Log("Chase 종료");
        }
    }
}