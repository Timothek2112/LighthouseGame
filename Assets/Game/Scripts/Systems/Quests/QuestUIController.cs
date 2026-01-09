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

    [ContextMenu("Create")]
    public void CreateQuestsUI()
    {
        foreach(var questObj in _controller.days[GameManager.Time.GetToday()].quests)
        {
            var newQuest = Instantiate(QuestUIPrefab);
            newQuest.transform.SetParent(QuestParent, false);
            var quest = newQuest.GetComponent<QuestUIAdapter>();
            quest.quest = questObj;
            quest.UpdatePresence();

            foreach(var stage in questObj.stages)
            {
                var newQuest1 = Instantiate(QuestUIPrefab);
                newQuest1.transform.SetParent(QuestParent, false);
                newQuest1.GetComponent<HorizontalLayoutGroup>().padding.left = stagePadding;
                var quest1 = newQuest1.GetComponent<QuestUIAdapter>();
                quest1.quest = stage;
                quest1.UpdatePresence();
            }
        }
        
    }
}
