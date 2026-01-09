using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class QuestUIAdapter : MonoBehaviour
{
    public Quest quest;

    [SerializeField]
    private TMP_Text title;
    [SerializeField]
    private TMP_Text stages;

    private void Awake()
    {
        UpdatePresence();
        QuestEvents.QuestUpdated += OnQuestUpdated;
    }

    private void OnDestroy()
    {
        QuestEvents.QuestUpdated -= OnQuestUpdated;
    }

    private void OnQuestUpdated(Quest quest)
    {
        if (quest != this.quest)
            return;

        UpdatePresence();
    }

    public void UpdatePresence()
    {
        if (quest == null)
            return;

        if(quest.Completed)
        {
            title.fontStyle |= FontStyles.Strikethrough;
            stages.fontStyle |= FontStyles.Strikethrough;
        }
        else
        {
            title.fontStyle &= FontStyles.Strikethrough;
            stages.fontStyle &= FontStyles.Strikethrough;
        }

        title.text = quest.title;

        if(quest.stages.Count > 0)
        {
            stages.text = quest.stages.Where(p => p.Completed).Count().ToString() + " / " + quest.stages.Count().ToString();
        }
        else
        {
            stages.text = "";
        }
    }
}
