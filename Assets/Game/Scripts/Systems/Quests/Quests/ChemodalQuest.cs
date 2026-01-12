using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemodalQuest : QuestInteractable
{
    public GameObject targetChemodan;
    public GameObject targetChemodanFinal;

    public override void PreInteract()
    {
        if(stage == 0)
            base.PreInteract();
        else if(stage == 1)
        {
            _outline.OutlineMode = Outline.Mode.OutlineAll;
        }
    }

    public override void Interact(PlayerController controller)
    {
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
        if (stage == 0)
            base.PostInteract();
        else if (stage == 1)
        {
            _outline.OutlineMode = Outline.Mode.OutlineAndSilhouette;
        }
    }
}
