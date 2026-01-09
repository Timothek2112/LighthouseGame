using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderController : MonoBehaviour
{
    public bool QuestsOpened = true;
    public bool MemoirsOpened = false;

    [SerializeField]
    private Color openedColor;
    [SerializeField]
    private Color closedColor;

    [SerializeField]
    private Image questsImage;
    [SerializeField]
    private Image memoirsImage;

    [SerializeField]
    private GameObject _questsContent;
    [SerializeField]
    private GameObject _memoirsContent;

    private void Awake()
    {
        UpdateVisibility();
    }

    private void UpdateVisibility()
    {
        _questsContent.SetActive(QuestsOpened);
        _memoirsContent.SetActive(MemoirsOpened);
        questsImage.color = QuestsOpened ? openedColor : closedColor;
        memoirsImage.color = MemoirsOpened ? openedColor : closedColor;

        
    }

    public void QuestsClick()
    {
        QuestsOpened = true;
        MemoirsOpened = false;
        UpdateVisibility();
    }

    public void MemoirsClick()
    {
        QuestsOpened = false;
        MemoirsOpened = true;
        UpdateVisibility();
    }
}
