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

    [SerializeField]
    private GameObject _notificationObject;

    private void Awake()
    {
        UpdateVisibility();
        QuestEvents.QuestUpdated += Notification;
    }

    private void OnDestroy()
    {
        QuestEvents.QuestUpdated -= Notification;
    }

    public void Notification(Quest quest)
    {
        if(quest.Completed && (!quest.isStage || quest.forceNotification))
        {
            _notificationObject.SetActive(true);
        }
    }

    public void HideNotification()
    {
        _notificationObject.SetActive(false);
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
