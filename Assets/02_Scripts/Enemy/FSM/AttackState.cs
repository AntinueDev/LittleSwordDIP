using UnityEngine;
using Logger = LittleSword.Common.Logger;

namespace LittleSword.Enemy.FSM
{
    public class AttackState : IState
    {
        public void Enter(Enemy enemy)
        {
            Logger.Log("공격 진입");
        }

        public void Update(Enemy enemy)
        {
            Logger.Log("공격 갱신");
        }

        public void Exit(Enemy enemy)
        {
            Logger.Log("공격 종료");
        }
    }
}