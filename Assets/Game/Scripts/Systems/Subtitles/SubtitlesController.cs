using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitlesController : MonoBehaviour
{
    [Header("Events")]
    public Action<Subtitle> SubtitlesEnded;

    public TMP_Text text;
    public bool displaying = false;
    public float defaultLetterSpeed = 0.1f;
    public GameObject gradient;

    private Coroutine ShowCoroutine;
    private Subtitle current;
    private bool wasDisplaying = false;

    public Queue<Subtitle> subtitlesQueue = new Queue<Subtitle>();

    public void AddToQueue(Subtitle content)
    {
        subtitlesQueue.Enqueue(content);
    }

    private void ShowNextInQueue()
    {
        current = subtitlesQueue.Dequeue();
        ShowCoroutine = StartCoroutine(Show(current));
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if(ShowCoroutine != null)
            {
                ShowAll();
            }
            else
            {
                EndShow();
            }
        }
    }

    private void FixedUpdate()
    {

        if (!displaying && subtitlesQueue.Count > 0)
        {
            ShowNextInQueue();
        }
    }

    public IEnumerator Show(Subtitle content)
    {
        wasDisplaying = true;
        if(gradient != null)
            gradient.SetActive(true);
        displaying = true;

        if (content.letterSpeed > 0 || defaultLetterSpeed > 0)
        {
            var letterSpeed = content.letterSpeed > 0 ? content.letterSpeed : defaultLetterSpeed;

            text.text = "";
            int i = 0;

            while(content.text != text.text)
            {
                text.text += content.text[i];
                yield return new WaitForSeconds(letterSpeed);
                i++;
            }
        }
        else
        {
            text.text = content.text;
        }

        if (!content.WaitForUser)
        {
            yield return new WaitForSeconds(content.time_to_show);

            EndShow();
        }
        else
        {
            ShowCoroutine = null;
        }
    }

    public void ShowAll()
    {
        StopCoroutine(ShowCoroutine);
        ShowCoroutine = null;
        text.text = current.text;
    }

    public void EndShow()
    {
        text.text = "";
        if (gradient != null)
            gradient.SetActive(false);
        displaying = false;
        ShowCoroutine = null;
        SubtitlesEnded?.Invoke(current);
    }
}
