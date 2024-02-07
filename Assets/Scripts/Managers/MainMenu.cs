using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        Time.timeScale = 1;
    }
    public void StartCampaign()
    {
        GameManager.Instance.GoToLevelByIndex(1);
    }

    public void ChooseLevel()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
