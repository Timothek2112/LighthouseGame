using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private Camera cam;
    [SerializeField] private Camera defaultCamera;

    public virtual bool PreConditions()
    {
        return true;
    }

    public void Activate()
    {
        if (!PreConditions())
            return;

        if (cam != null)
        {
            cam.enabled = true;
            Camera.main.enabled = false;
        }
    }

    public virtual void StartMinigame()
    {


    }

    public void Deactivate()
    {
        if (cam != null)
        {
            Camera.main.enabled = true;
            cam.enabled = false;
        }
    }
}
