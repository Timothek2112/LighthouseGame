using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public enum SubtitlesType
{
    Main,
    Center
}

[Serializable]
public class TypeController
{
    public SubtitlesType Type;
    public SubtitlesController Controller;
}

public class SubtitlesManager : MonoBehaviour
{
    public List<TypeController> Controllers = new List<TypeController>();

    public void Show(SubtitlesType type, Subtitle content)
    {
        Controllers.FirstOrDefault(p => p.Type == type).Controller.AddToQueue(content);
    }

    public SubtitlesController GetController(SubtitlesType type)
    {
        return Controllers.FirstOrDefault(p => p.Type == type).Controller;
    }
}
