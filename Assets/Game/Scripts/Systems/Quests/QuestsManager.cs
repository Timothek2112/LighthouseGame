using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    [SerializeField]
    private QuestController _questController;

    private void Awake()
    {
        _questController = GameObject.FindGameObjectWithTag("QuestsController").GetComponent<QuestController>();
    }

    public void Complete(Quest quest, int day = -1, int stage = -1)
    {
        if (day == -1)
            day = GameManager.Time.GetToday();

        _questController.Complete(quest, day, stage);
    }
}
