using Rubickanov.Logger;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
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

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        private GameInput gameInput;

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

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
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
    }
}