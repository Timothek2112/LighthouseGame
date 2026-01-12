using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIController : MonoBehaviour
{
    [SerializeField]
    private QuestController _controller;

    [SerializeField]
    private GameObject QuestUIPrefab;
    [SerializeField]
    private Transform QuestParent;
    public int stagePadding = 50;

    private void Awake()
    {
        GameManager.Time.DayChanged += DayChanged;
        QuestEvents.QuestUpdated += QuestUpdated;
    }

    private void QuestUpdated(Quest quest)
    {
        CreateQuestsUI();
    }

    private void DayChanged(int today)
    {
        CreateQuestsUI();
    }

    [ContextMenu("Create")]
    public void CreateQuestsUI()
    {
        ClearQuestsUI();

        foreach (var questObj in _controller.days[GameManager.Time.GetToday()].quests)
        {
            if (!questObj.PrerequisitesDone())
            {
                continue;
            }
            
            var newQuest = Instantiate(QuestUIPrefab);
            newQuest.transform.SetParent(QuestParent, false);
            var quest = newQuest.GetComponent<QuestUIAdapter>();
            quest.quest = questObj;
            quest.UpdatePresence();

            foreach(var stage in questObj.stages)
            {
                if (!stage.PrerequisitesDone())
                    continue;

                var newQuest1 = Instantiate(QuestUIPrefab);
                newQuest1.transform.SetParent(QuestParent, false);
                newQuest1.GetComponent<HorizontalLayoutGroup>().padding.left = stagePadding;
                var quest1 = newQuest1.GetComponent<QuestUIAdapter>();
                quest1.quest = stage;
                quest1.UpdatePresence();
            }
        }

        // Принудительное обновление всех Canvas
        Canvas.ForceUpdateCanvases();

        // Обновление Layout
        LayoutRebuilder.ForceRebuildLayoutImmediate(QuestParent.GetComponent<RectTransform>() );

        // Еще одно обновление для надежности
        Canvas.ForceUpdateCanvases();

    }

    private void ClearQuestsUI()
    {
        for(int i = 0; i < QuestParent.childCount; i++)
        {
            Destroy(QuestParent.GetChild(i).gameObject);
        }
    }
}
