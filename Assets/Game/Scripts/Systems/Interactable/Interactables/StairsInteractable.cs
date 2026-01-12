using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsInteractable : Interactable
{
    [SerializeField]
    private Transform Teleport;
    private PlayerController controller;

    public override void Interact(PlayerController controller)
    {
        this.controller = controller;
        base.Interact(controller);
        GameManager.Screen.Dark(0.3f);
        Invoke("Light", 0.4f);
    }

    public void Light()
    {
        controller.transform.position = Teleport.position;
        GameManager.Screen.Light(0.3f);
    }
}
