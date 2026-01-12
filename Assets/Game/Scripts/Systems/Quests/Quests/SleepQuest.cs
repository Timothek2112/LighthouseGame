using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepQuest : QuestInteractable
{
    public override void Interact(PlayerController controller)
    {
        base.Interact(controller);
        GameManager.Screen.Dark(0.5f);
        GameManager.Time.NextDay();

        Invoke("Sleep", 1f);
    }

    private void Sleep()
    {
        GameManager.Screen.Light(0.5f);
    }
}
