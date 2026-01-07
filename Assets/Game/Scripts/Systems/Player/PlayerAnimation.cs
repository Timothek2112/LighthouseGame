using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void TakeAnimation()
    {
        animator.Play("Take");
    }

}
