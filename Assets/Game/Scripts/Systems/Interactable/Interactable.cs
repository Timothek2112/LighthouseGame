using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private Outline _outline;
    [SerializeField] private float _outlineWidth = 3;

    public void PreInteract()
    {
        if(_outline != null)
            _outline.OutlineWidth = _outlineWidth;
    }

    public virtual void Interact(PlayerController controller)
    {

    }

    public void PostInteract()
    {
        if (_outline != null)
            _outline.OutlineWidth = 0;
    }
}
