using UnityEngine;

namespace LittleSword.Player.Controllers
{
    public class AnimationController
    {
        private readonly Animator animator;

        private static readonly int hashIsRun = Animator.StringToHash("IsRun");
        private static readonly int hashAttack = Animator.StringToHash("Attack");
        private static readonly int hashHit = Animator.StringToHash("Hit");
        private static readonly int hashDie = Animator.StringToHash("Die");
        
        // 생성자 (Dependency Injection)
        public AnimationController(Animator animator)
        {
            this.animator = animator;
        }
        
        public void Move(bool isMoving)
        {
            animator.SetBool(hashIsRun, isMoving);
        }

        public void Attack()
        {
            animator.SetTrigger(hashAttack);
        }

        public void Hit()
        {
            animator.SetTrigger(hashHit);
        }

        public void Die()
        {
            animator.SetTrigger(hashDie);
        }
    }

}