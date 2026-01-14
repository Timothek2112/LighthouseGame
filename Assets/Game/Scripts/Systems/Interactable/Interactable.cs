using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected Outline _outline;
    [SerializeField] protected float _outlineWidth = 3;

    private float _outlineStart = 0;

    public virtual void PreInteract()
    {
        if (_outline != null)
        {
            _outlineStart = _outline.OutlineWidth;
            _outline.OutlineWidth = _outlineWidth;
        }
    }

    public virtual void Interact(PlayerController controller)
    {

    }

    public virtual void PostInteract()
    {
        if (_outline != null)
            _outline.OutlineWidth = _outlineStart;
    }
}
