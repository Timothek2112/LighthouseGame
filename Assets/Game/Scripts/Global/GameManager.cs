using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static QuestsManager Quests;
    public static TimeManager Time;
    public static SubtitlesManager Subtitles;
    public static ScreenManager Screen;
    public static UIManager UI;

    public Quest firstQuest;

    [Header("Story")]
    [SerializeField] Intro intro;

    void Awake()
    {
        Application.targetFrameRate = 60;
        Quests = GetComponent<QuestsManager>();
        Time = GetComponent<TimeManager>();
        Subtitles = GetComponent<SubtitlesManager>();
        Screen = GetComponent<ScreenManager>();
        UI = GetComponent<UIManager>();
        UI.CreateQuestsUI();

        intro.Play();
        try
        {
            QuestEvents.QuestUpdated?.Invoke(firstQuest);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

}
