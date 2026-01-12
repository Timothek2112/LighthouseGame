using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public List<QuestDayController> days = new List<QuestDayController>();

    public void Complete(Quest quest, int day, int stage = -1)
    {
        int index = days[day].quests.IndexOf(quest);
        days[day].quests[index].Complete(stage);
    }
}
