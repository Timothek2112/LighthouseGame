using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
public class PlayerController : MonoBehaviour
{
    public PlayerAnimation animation;

    private void Awake()
    {
        animation = GetComponent<PlayerAnimation>();
    }
}
