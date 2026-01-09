using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string title;
    [SerializeField]
    public bool Completed;
    public List<Quest> stages = new List<Quest>();

    public void Complete(int stage = -1)
    {
        if (stage == -1 || stage == stages.Count - 1)
            Completed = true;
        else
            stages[stage].Complete();

        QuestEvents.QuestUpdated?.Invoke(this);
    }
}
