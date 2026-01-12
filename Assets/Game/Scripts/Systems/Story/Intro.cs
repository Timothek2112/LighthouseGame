using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public List<Subtitle> subtitlesMain = new List<Subtitle>();
    public Subtitle lastSubtitle;

    public void Play()
    {
        GameManager.Screen.Dark(0);

        foreach(var subtitle in subtitlesMain)
        {
            GameManager.Subtitles.Show(SubtitlesType.Center, subtitle);
        }

        GameManager.Subtitles.GetController(SubtitlesType.Center).SubtitlesEnded += FadeOut;
    }

    private void FadeOut(Subtitle subtitle)
    {
        if (lastSubtitle != subtitle)
            return;

        GameManager.Screen.Light(1);
        GameManager.Subtitles.GetController(SubtitlesType.Center).SubtitlesEnded -= FadeOut;
    }
}
