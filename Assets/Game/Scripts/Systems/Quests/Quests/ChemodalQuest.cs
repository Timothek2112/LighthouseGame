using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemodalQuest : QuestInteractable
{
    public GameObject targetChemodan;
    public GameObject targetChemodanFinal;

    public override void PreInteract()
    {
        base.PreInteract();
    }

    public override void Interact(PlayerController controller)
    {
        if (!quest.PrerequisitesDone() || quest.Completed)
            return;

        base.Interact(controller);
        if(stage == 0)
        {
            GameManager.Quests.Complete(quest, GameManager.Time.GetToday(), stage);
            targetChemodan.SetActive(true);
            gameObject.SetActive(false);
        }
        else if(stage == 1)
        {
            targetChemodanFinal.SetActive(true);
            targetChemodan.SetActive(false);
            GameManager.Quests.Complete(quest, GameManager.Time.GetToday(), stage);
        }
    }

    public override void PostInteract()
    {
        base.PostInteract();
    }
}
