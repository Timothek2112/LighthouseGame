using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDayController : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
    public int day;

    private void Awake()
    {
        foreach (var quest in quests)
        {
            quest.day = day;
        }
    }
}
