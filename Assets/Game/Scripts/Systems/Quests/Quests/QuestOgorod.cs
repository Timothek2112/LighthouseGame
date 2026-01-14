using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOgorod : QuestInteractable
{
    public GameObject OgorodGood;

    public override void Interact(PlayerController controller)
    {
        if (!quest.PrerequisitesDone() || quest.Completed)
            return;

        base.Interact(controller);
        OgorodGood.SetActive(true);
        gameObject.SetActive(false);
        GameManager.Screen.Dark(0.5f);
        Invoke("Light", 1f);
    }

    private void Light()
    {
        GameManager.Screen.Light(0.5f);
    }
}
