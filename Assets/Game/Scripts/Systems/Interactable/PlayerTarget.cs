using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private float interactionRange = 3f;
    [SerializeField] private LayerMask interactionLayer;

    [Header("Ссылки")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Camera playerCamera;

    [SerializeField] private Interactable currentInteractable;

    private void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact(playerController);
        }
    }

    void CheckForInteractable()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, interactionLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            SetInteractable(interactable);
        }
        else
        {
            SetInteractable(null);
        }
    }

    void SetInteractable(Interactable interactable)
    {
        if (currentInteractable != null)
            currentInteractable.PostInteract();
        currentInteractable = interactable;
        if(currentInteractable != null)
            currentInteractable.PreInteract();
    }
}
