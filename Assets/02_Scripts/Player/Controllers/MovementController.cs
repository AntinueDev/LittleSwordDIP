using UnityEngine;

namespace LittleSword.Player.Controllers
{
    public class MovementController
    {
        private readonly Rigidbody2D rb;    
        private readonly SpriteRenderer spriteRenderer;
        
        // 생성자
        public MovementController(Rigidbody2D rb, SpriteRenderer spriteRenderer)
        {
            this.rb = rb;
            this.spriteRenderer = spriteRenderer;
        }
        
        // 이동 메소드
        public void Move(Vector2 direction, float moveSpeed)
        {
            rb.linearVelocity = direction * moveSpeed;

            if (direction != Vector2.zero)
            {
                spriteRenderer.flipX = direction.x < 0.0f;
            }
        }
    }
}