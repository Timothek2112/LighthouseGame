using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameInteractable : Interactable
{
    public Minigame minigame;

    public override void Interact(PlayerController controller)
    {
        minigame.Activate();
        minigame.StartMinigame();
    }
}
