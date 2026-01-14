using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateQuest : QuestInteractable
{
    public override void Interact(PlayerController controller)
    {
        base.Interact(controller);
        gameObject.SetActive(false);
    }
}
