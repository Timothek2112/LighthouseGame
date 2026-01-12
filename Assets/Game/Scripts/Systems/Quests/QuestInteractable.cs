using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInteractable : Interactable
{
    public Quest quest;
    public int stage;

    private void Awake()
    {
        QuestEvents.QuestUpdated += OnQuestUpdate;
    }

    private void OnDestroy()
    {
        QuestEvents.QuestUpdated -= OnQuestUpdate;
    }

    private void OnQuestUpdate(Quest quest)
    {
        if (this.quest.PrerequisitesDone())
            _outline.OutlineMode = Outline.Mode.SilhouetteOnly;
    }

    public override void PreInteract()
    {
        if (GameManager.Time.GetToday() != quest.day)
            return;
        if(quest != null)
        {
            if (!quest.PrerequisitesDone())
            {
                return;
            }
        }

        base.PreInteract();
    }

    public override void Interact(PlayerController controller)
    {
        base.Interact(controller);
        GameManager.Quests.Complete(quest, GameManager.Time.GetToday(), stage);
    }

    public override void PostInteract()
    {
        if (GameManager.Time.GetToday() != quest.day)
            return;
        if (quest != null)
        {
            if (!quest.PrerequisitesDone())
            {
                return;
            }
        }
        base.PostInteract();
    }
}
