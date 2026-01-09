using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilerInteractable : Interactable
{
    public Quest quest;

    public override void Interact(PlayerController playerController)
    {
        playerController.animation.TakeAnimation();
        GameManager.Quests.Complete(quest);
        Destroy(gameObject);
    }
}
