using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private int today = 0;

    public int GetToday()
    {
        return today;
    }

    public void NextDay()
    {
        today++;
    }
}
