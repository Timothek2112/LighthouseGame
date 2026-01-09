using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static QuestsManager Quests;
    public static TimeManager Time;

    void Awake()
    {
        Application.targetFrameRate = 60;
        Quests = GetComponent<QuestsManager>();
        Time = GetComponent<TimeManager>();
    }

}
