using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilerInteractable : Interactable
{
    public override void Interact(PlayerController playerController)
    {
        playerController.animation.TakeAnimation();
        Destroy(gameObject);
    }
}
