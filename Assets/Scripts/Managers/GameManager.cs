using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static int currentLevel;
    private static string[] levels = { "levelZero","SampleScene", "TutorialScene" };

    void Awake()
    {
        currentLevel = 1;

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(levels[currentLevel]);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        currentLevel = 0;
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(levels[currentLevel+1]);
        currentLevel += 1;
    }

    public void GoToLevelByIndex(int index)
    {
        SceneManager.LoadScene(levels[index]);
        currentLevel = index;
    }
}
