using ALG.Input;
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
            InputReader.Instance.IsCursorForUI(true);
        }
    }
}
