using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapustaQuest : QuestInteractable
{
    public GameObject Kapusta;
    public bool used = false;

    public override void Interact(PlayerController controller)
    {
        if (!quest.PrerequisitesDone() || quest.Completed)
            return;

        if (used)
            return;

        base.Interact(controller);
        Kapusta.SetActive(true);
        gameObject.SetActive(false);
        used = true;
    }
}
