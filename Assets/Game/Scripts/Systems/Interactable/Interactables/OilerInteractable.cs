using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilerInteractable : QuestInteractable
{
    public Subtitle Subtitle;

    public override void Interact(PlayerController playerController)
    {
        playerController.animation.TakeAnimation();
        GameManager.Quests.Complete(quest, GameManager.Time.GetToday(), 0);
        GameManager.Subtitles.Show(SubtitlesType.Main, Subtitle);
        Destroy(gameObject);
    }
}
