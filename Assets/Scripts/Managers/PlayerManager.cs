using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerManager : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    public UnityEvent gameOver;
    public UnityEvent playerTwoDeath;

    private Player playerOneScript;
    private Player playerTwoScript;

    private bool playerTwoIsDead;

    void Awake()
    {
        playerOneScript = playerOne.GetComponent<Player>();
        playerTwoScript = playerTwo.GetComponent<Player>();

        playerOneScript.playerDeath.AddListener(PlayerOneDeath);
        playerTwoScript.playerDeath.AddListener(PlayerTwoDeath);

        playerTwoIsDead = false;
    }

    void PlayerOneDeath()
    {
        gameOver.Invoke();
    }

    void PlayerTwoDeath()
    {
        Destroy(playerTwo);

        playerTwoIsDead = true;
        playerTwoDeath.Invoke();
    }

    public void PausePlayerActions()
    {
        playerOneScript.DisableMovement();
        playerOneScript.DisableShooting();
        if (!playerTwoIsDead)
        {
            playerTwoScript.DisableMovement();
            playerTwoScript.DisableShooting();
        }
    }

    public void ResumePlayerActions()
    {
        playerOneScript.EnableMovement();
        playerOneScript.EnableShooting();
        if (!playerTwoIsDead)
        {
            playerTwoScript.EnableMovement();
            playerTwoScript.EnableShooting();
        }
    }
}
