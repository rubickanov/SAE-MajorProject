using System;
using ALG.Input;
using UnityEngine;

namespace ALG.Player
{
    public class CursorController : MonoBehaviour
    {
        public static CursorController Instance { get; private set; }

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

        private void OnApplicationFocus(bool hasFocus)
        {
            InputReader.Instance.SetCursorLockState(InputReader.Instance.cursorLocked);
        }

        private void Start()
        {
            IsCursorForUI(false);
        }

        public void IsCursorForUI(bool isCursorForUI)
        {
            InputReader.Instance.SetCursorLockState(!isCursorForUI);
            InputReader.Instance.cursorInputForLook = !isCursorForUI;
            Cursor.visible = isCursorForUI;
        }
    }
}