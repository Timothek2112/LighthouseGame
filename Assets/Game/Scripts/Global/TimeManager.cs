using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private int today = 0;
    [SerializeField]
    private Light sun;

    public Action<int> DayChanged;

    public int GetToday()
    {
        return today;
    }

    public void NextDay()
    {
        today++;
        try
        {
            DayChanged?.Invoke(today);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}
