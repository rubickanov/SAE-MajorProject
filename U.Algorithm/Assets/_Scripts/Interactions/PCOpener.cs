using ALG.Input;
using ALG.Player;
using UnityEngine;

namespace ALG.Interactions
{
    public class PCOpener : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private GameObject desktopUI;

        public void Interact()
        {
            desktopUI.SetActive(true);
            CursorController.Instance.IsCursorForUI(true);
        }
    }
}