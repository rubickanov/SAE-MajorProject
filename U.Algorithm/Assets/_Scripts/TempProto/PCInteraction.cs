using UnityEngine;

namespace ALG.TempProto
{
    public class PCInteraction : MonoBehaviour
    {
        public GameObject osUI;
        public GameObject interactPopUp;
        public bool isActive = false;
        public Transform pc;
        public float distanceToInteract;

        private void Update()
        {
            if ((transform.position - pc.transform.position).magnitude < distanceToInteract)
            {
                if (!isActive)
                {
                    // pop up and can be interacted
                    isActive = true;
                    interactPopUp.SetActive(true);
                }
            }
            else
            {
                if (isActive)
                {
                    // pop up and can be interacted
                    isActive = false;
                    interactPopUp.SetActive(false);
                }
            }

            if (isActive)
            {
                if (UnityEngine.Input.GetKeyDown(KeyCode.F))
                {
                    osUI.SetActive(true);
                }
            }
        }
    }
}