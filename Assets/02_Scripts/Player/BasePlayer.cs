using System;
using UnityEngine;
using LittleSword.InputSystem;
using LittleSword.Player.Controllers;
using Logger = LittleSword.Common.Logger;

namespace LittleSword.Player
{
    public class BasePlayer : MonoBehaviour
    {
        // Controller 설정
        private InputHandler inputHandler;
        private MovementController movementController;
        
        // Components 캐싱 변수
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;

        #region 유니티 이벤트
        protected void Awake()
        {
            InitComponents();
            InitController();
        }

        protected void OnEnable()
        {
            inputHandler.OnMove += Move;
            inputHandler.OnAttack += Attack;
        }

        protected void OnDisable()
        {
            inputHandler.OnMove -= Move;
            inputHandler.OnAttack -= Attack;
        }
        #endregion

        #region 공통 메소드
        private void Move(Vector2 direction)
        {
            movementController.Move(direction, 5.0f);
            Logger.Log("이동 처리");
        }
        
        private void Attack()
        {
            Logger.Log("공격 로직");
        }
        #endregion
        
        #region 초기화 로직
        private void InitController()
        {
            inputHandler = GetComponent<InputHandler>();
            movementController = new MovementController(rb, spriteRenderer);
        }
        
        private void InitComponents()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0.0f;
            rb.freezeRotation = false;

            spriteRenderer = GetComponent<SpriteRenderer>();
        }        
        #endregion
    }
}