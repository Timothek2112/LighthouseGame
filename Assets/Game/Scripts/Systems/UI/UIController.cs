using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] Animator _tabAnimator;
    [SerializeField] PlayerController _pController;
    bool opened = false;

    private void Awake()
    {
        _pController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab) && opened)
        {
            CloseTab();
        }
        else if (Input.GetKeyUp(KeyCode.Tab) && !opened)
        {
            OpenTab();
        }
    }

    public void OpenTab()
    {
        _tabAnimator.SetBool("Opened", true);
        opened = true;
        _pController.LockMovement();
        _pController.ShowCursor();
    }

    public void CloseTab()
    {
        _tabAnimator.SetBool("Opened", false);
        opened = false;
        _pController.UnlockMovement();
        _pController.HideCursor();
    }

}
