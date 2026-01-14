using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateQuest : QuestInteractable
{
    public override void Interact(PlayerController controller)
    {
        if (!quest.PrerequisitesDone() || quest.Completed)
            return;

        base.Interact(controller);
        gameObject.SetActive(false);
    }
}
