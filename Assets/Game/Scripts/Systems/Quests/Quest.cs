using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string title;
    [SerializeField]
    public bool Completed;
    public List<Quest> stages = new List<Quest>();
    public int day;
    public bool isStage = false;
    public bool forceNotification = false;
    public int taskCount = 0;
    public int taskCurrent = 0;

    public List<Quest> Prerequisites = new List<Quest>();

    private void Awake()
    {
        foreach(var stage in stages)
        {
            stage.isStage = true;
        }
    }

    public void Complete(int stage = -1)
    {
        if (stage == -1 || stage == stages.Count - 1)
        {
            if(taskCount > 0)
            {
                taskCurrent++;

                if (taskCurrent >= taskCount)
                {
                    Completed = true;
                    taskCurrent = taskCount;
                }
            }
            else
            {
                Completed = true;
                try
                {
                    if (stage != -1)
                    {
                        stages[stage].Complete();
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }

            }
        }
        else
        {
            stages[stage].Complete();
        }

        try
        {
            QuestEvents.QuestUpdated?.Invoke(this);
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    public bool PrerequisitesDone()
    {
        if (Prerequisites.Count == 0)
        {
            if(GameManager.Time.GetToday() == day)
            {
                return true;
            }
        }

        return Prerequisites.Where(p => p.Completed).ToList().Count == Prerequisites.Count && GameManager.Time.GetToday() == day;
    }

    public string GetCount()
    {

        if (taskCount > 0)
        {
            return taskCurrent.ToString() + "/" + taskCount.ToString();
        }

        if (stages.Count > 0)
        {
            return stages.Where(p => p.Completed).ToList().Count.ToString() + "/" + stages.Count;
        }

        return "";
    }
}
