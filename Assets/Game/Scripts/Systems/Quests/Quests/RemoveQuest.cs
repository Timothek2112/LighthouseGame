using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveQuest : QuestInteractable
{
    public override void Interact(PlayerController controller)
    {
        base.Interact(controller);
        GameManager.Screen.Dark(0.5f);
        Invoke("Light", 1f);
    }

    private void Light()
    {
        gameObject.SetActive(false);
        GameManager.Screen.Light(0.5f);
    }
}
