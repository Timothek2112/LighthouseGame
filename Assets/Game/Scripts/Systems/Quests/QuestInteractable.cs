using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInteractable : Interactable
{
    public Quest quest;
    public int stage;
    public float _staticOutlineWidth = 8;

    public Subtitle subtitle;

    private void Awake()
    {
        QuestEvents.QuestUpdated += OnQuestUpdate;
        GameManager.Subtitles.GetController(SubtitlesType.Center).SubtitlesEnded += OnSubtitleEnd;
    }

    private void OnDestroy()
    {
        QuestEvents.QuestUpdated -= OnQuestUpdate;
    }

    private void OnQuestUpdate(Quest quest)
    {
        if (this.quest == null)
            return;

        if (this.quest.PrerequisitesDone())
        {
            _outline.OutlineWidth = _staticOutlineWidth;
            _outline.OutlineMode = Outline.Mode.OutlineAndSilhouette;
            OnQuestAccesed();
        }

        if (this.quest.Completed)
        {
            _outline.OutlineMode = Outline.Mode.OutlineAll;
            _outline.OutlineWidth = 0;
        }
    }

    public override void PreInteract()
    {
        if (quest == null)
            return;

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
        if (!quest.PrerequisitesDone() || quest.Completed)
            return;

        base.Interact(controller);
        GameManager.Quests.Complete(this.quest, quest.day, stage);
        if(subtitle != null && quest.Completed)
        {
            GameManager.Subtitles.Show(SubtitlesType.Main, subtitle);
        }
    }

    private void OnSubtitleEnd(Subtitle subtitle)
    {
    }

    public override void PostInteract()
    {
        if (quest == null)
            return;

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

    public virtual void OnQuestAccesed()
    {

    }
}
