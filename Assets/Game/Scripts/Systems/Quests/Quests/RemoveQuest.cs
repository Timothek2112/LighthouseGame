using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveQuest : QuestInteractable
{
    public bool turnOffLight = true;
    public override void Interact(PlayerController controller)
    {
        base.Interact(controller);
        if (turnOffLight)
        {
            GameManager.Screen.Dark(0.5f);
            Invoke("Light", 1f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().LockMovement();
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }

    private void Light()
    {
        gameObject.SetActive(false);
        if(turnOffLight)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UnlockMovement();
        }

        GameManager.Screen.Light(0.5f);
    }
}
