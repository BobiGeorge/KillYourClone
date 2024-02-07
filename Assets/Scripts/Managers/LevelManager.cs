using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    InCombat,
    Paused,
    Dialogue
}

public abstract class LevelManager : MonoBehaviour
{
    public GameObject canvas; //not using it?
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject levelCompletedMenu;

    public GameObject playerOne;
    public GameObject playerTwo;

    public PlayerManager playerManager;
    public EnemyManager enemyManager;
    public DialogueManager dialogueManager;

    protected GameState State;
    protected GameState PreviousState;


    private void Awake()
    {
        State = GameState.InCombat;

        playerManager.gameOver.AddListener(GameOver);
        dialogueManager.dialogueEnd.AddListener(HideDialogue);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (State == GameState.InCombat)
                PauseGame();
            else
                ResumeGame();
        }

        if(State == GameState.Dialogue)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                dialogueManager.DisplayDialogue();
            }
        }
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.InCombat:
                break;
            case GameState.Paused:
                break;
            case GameState.Dialogue:
                break;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PreviousState = State;
        playerManager.PausePlayerActions();
        pauseMenu.SetActive(true);

        UpdateGameState(GameState.Paused);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        playerManager.ResumePlayerActions();
        Time.timeScale = 1;

        UpdateGameState(PreviousState);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        playerManager.PausePlayerActions();
    }

    public void DisplayDialogue()
    {
        Time.timeScale = 0;
        PreviousState = State;
        playerManager.PausePlayerActions();
        dialogueManager.DisplayDialogueBox();

        dialogueManager.DisplayDialogue();

        UpdateGameState(GameState.Dialogue);
    }


    public void HideDialogue()
    {
        dialogueManager.HideDialogueBox();
        playerManager.ResumePlayerActions();
        Time.timeScale = 1;

        UpdateGameState(PreviousState);
    }

    public void EndLevel()
    {
        playerManager.PausePlayerActions();
        Time.timeScale = 0;
        levelCompletedMenu.SetActive(true);
    }

    public void Retry()
    {
        GameManager.Instance.RetryLevel();
    }

    public void ExitGame()
    {
        GameManager.Instance.GoToMainMenu();
    }

    public abstract bool CheckLevelEndConditions();
}
