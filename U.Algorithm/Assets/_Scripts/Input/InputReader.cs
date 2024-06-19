using System;
using Rubickanov.Logger;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ALG.Input
{
    public class InputReader : MonoBehaviour, GameInput.IGameplayActions
    {
        public static InputReader Instance { get; private set; }
        [SerializeField] private RubiLogger logger;

        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;
        public bool interact;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        private GameInput gameInput;
        
        
        // EVENTS
        public Action OnInteractPerformed;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnEnable()
        {
            if (gameInput != null) return;

            gameInput = new GameInput();

            gameInput.Gameplay.SetCallbacks(this);
            gameInput.Gameplay.Enable();
            logger.Log(LogLevel.Info, "Gameplay Input enabled", this, LogOutput.ConsoleAndFile);
        }

        private void OnDisable()
        {
            gameInput.Gameplay.Disable();
            logger.Log(LogLevel.Info, "Gameplay Input disabled", this, LogOutput.ConsoleAndFile);
        }

        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveInput(context.ReadValue<Vector2>());
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            if (cursorInputForLook)
            {
                LookInput(context.ReadValue<Vector2>());
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            JumpInput(context.ReadValueAsButton());
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            SprintInput(context.ReadValueAsButton());
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            interact = context.ReadValueAsButton();
            if (context.performed)
            {
                OnInteractPerformed?.Invoke();
                logger.Log(LogLevel.Debug, "Interact performed", this);
            }
        }
        
        public void SetCursorLockState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}