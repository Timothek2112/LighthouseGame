using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgorodQuest : QuestInteractable
{
    public GameObject PochinenijOgorod;

    public override void Interact(PlayerController controller)
    {
        if (!quest.PrerequisitesDone() || quest.Completed)
            return;

        base.Interact(controller);
        GameManager.Screen.Dark(0.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().LockMovement();
        Invoke("Light", 1f);

    }

    public void Light()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UnlockMovement();
        GameManager.Screen.Light(0.5f);
        PochinenijOgorod.SetActive(true);
        gameObject.SetActive(false);
    }
}
