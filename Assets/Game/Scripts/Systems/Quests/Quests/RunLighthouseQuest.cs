using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunLighthouseQuest : QuestInteractable
{
    public Subtitle endSubtitle;
    public Subtitle thanksSubtitle;

    public override void Interact(PlayerController controller)
    {
        if (!quest.PrerequisitesDone() || quest.Completed)
            return;

        base.Interact(controller);

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().LockMovement();
        GameManager.Screen.Dark(0);

        GameManager.Subtitles.Show(SubtitlesType.Center, endSubtitle);
        GameManager.Subtitles.Show(SubtitlesType.Center, thanksSubtitle);

    }
}
