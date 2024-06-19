using System;
using ALG.Input;
using UnityEngine;
using ALG.Interactions;
using Rubickanov.Logger;

namespace ALG.Player
{
    public class InteractDetector : MonoBehaviour
    {
        [SerializeField]
        private RubiLogger logger;
        [SerializeField]
        private Transform origin;
        [SerializeField]
        private float distance;
        [SerializeField]
        private GameObject uiInteractPopUp;

        private IInteractable interactable;
        private RaycastHit hitInfo;
        private bool rayHitInteractable;

        public Action OnInteractableHit;
        public Action OnInteractableStopHit;

        private void Start()
        {
            InputReader.Instance.OnInteractPerformed += OnInteract;
        }
        
        private void Update()
        {
            CheckInteractables();
        }

        private void OnInteract()
        {
            if (rayHitInteractable || interactable != null)
            {
                interactable.Interact();
            }
        }

        private void CheckInteractables()
        {
            // RayCasting
            if (Physics.Raycast(origin.position, origin.forward, out hitInfo, distance))
            {
                // Check if we hit IInteractable object
                if (hitInfo.collider.TryGetComponent(out interactable))
                {
                    // HITTED
                    if (!rayHitInteractable)
                    {
                        uiInteractPopUp.SetActive(true);

                        OnInteractableHit?.Invoke();
                        rayHitInteractable = true;
                        logger.Log(LogLevel.Debug, $"Interactable object HIT: {hitInfo.collider.name}", this);
                    }
                }
                else
                {
                    // NOT HITTED
                    if (rayHitInteractable)
                    {
                        uiInteractPopUp.SetActive(false);

                        OnInteractableStopHit?.Invoke();
                        rayHitInteractable = false;
                        logger.Log(LogLevel.Debug, $"Interactable object STOP hit", this);
                    }
                }
            }
            else
            {
                // NOT HITTED
                if (rayHitInteractable)
                {
                    uiInteractPopUp.SetActive(false);

                    OnInteractableStopHit?.Invoke();
                    rayHitInteractable = false;
                    logger.Log(LogLevel.Debug, $"Interactable object STOP hit", this);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = rayHitInteractable ? Color.green : Color.red;
            Gizmos.DrawRay(origin.position, origin.forward * distance);
        }
    }
}