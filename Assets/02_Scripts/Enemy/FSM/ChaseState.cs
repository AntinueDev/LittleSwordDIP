using UnityEngine;
using Logger = LittleSword.Common.Logger;

namespace LittleSword.Enemy.FSM
{
    public class ChaseState : IState
    {
        public void Enter(Enemy enemy)
        {
            Logger.Log("Chase 진입");
        }

        public void Update(Enemy enemy)
        {
            Logger.Log("Chase 갱신");
        }

        public void Exit(Enemy enemy)
        {
            Logger.Log("Chase 종료");
        }
    }
}