using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepQuest : QuestInteractable
{
    public GameObject newKrovat;

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
        if (newKrovat != null)
        {
            newKrovat.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public override void OnQuestAccesed()
    {
        base.OnQuestAccesed();

    }
}
