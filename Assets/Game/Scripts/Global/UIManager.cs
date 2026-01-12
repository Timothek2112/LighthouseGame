using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIController Controller;

    public void CreateQuestsUI()
    {
        Controller.CreateQuestUI();
    }
}
