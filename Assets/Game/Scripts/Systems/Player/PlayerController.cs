using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
public class PlayerController : MonoBehaviour
{
    public PlayerAnimation animation;
    [SerializeField] private Rigidbody _body;
    public bool Locked = false;

    private void Awake()
    {
        animation = GetComponent<PlayerAnimation>();
    }

    public void LockMovement()
    {
        _body.isKinematic = true;
        Locked = true;
    }

    public void UnlockMovement()
    {
        _body.isKinematic = false;
        Locked = false;
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
