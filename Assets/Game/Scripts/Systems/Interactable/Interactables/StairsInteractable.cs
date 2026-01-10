using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsInteractable : Interactable
{
    [SerializeField]
    private Transform Teleport;

    public override void Interact(PlayerController controller)
    {
        base.Interact(controller);
        controller.transform.position = Teleport.position;
    }
}
