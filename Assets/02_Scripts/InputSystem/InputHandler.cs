using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Logger = LittleSword.Common.Logger;

namespace LittleSword.InputSystem
{
    public class InputHandler : MonoBehaviour, IInputEvent
    {
        public event Action<Vector2> OnMove;
        public event Action OnAttack;
        
        // InputAction 연결
        private InputSystem_Actions inputActions;
        private InputAction moveAction;
        private InputAction attackAction;

        private void Awake()
        {
            inputActions = new InputSystem_Actions();
            moveAction = inputActions.Player.Move;
            attackAction = inputActions.Player.Attack;
        }

        private void OnEnable()
        {
            inputActions.Enable();
            moveAction.performed += HandleMove;
            moveAction.canceled += HandleMove;
            attackAction.performed += HandleAttack;
        }
        private void OnDisable()
        {
            inputActions.Disable();
            moveAction.performed -= HandleMove;
            moveAction.canceled -= HandleMove;            
            attackAction.performed -= HandleAttack;
        }

        private void HandleAttack(InputAction.CallbackContext ctx)
        {
            OnAttack?.Invoke();
        }

        private void HandleMove(InputAction.CallbackContext ctx)
        {
            OnMove?.Invoke(ctx.ReadValue<Vector2>());
        }
    }
}