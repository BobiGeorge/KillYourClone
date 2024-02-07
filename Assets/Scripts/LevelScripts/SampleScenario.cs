using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleScenario : LevelManager
{
    public GameObject spawnerOne;
    public GameObject spawnerTwo;
 
    public Sprite playerTerry;
    public Sprite playerPharaoh;

    private int enemyDeathGoal;
    private int firstDialogueGoal;
    private int levesStage;

    void Update()
    { 
        base.Update();

        if(levesStage == 1 && firstDialogueGoal <= enemyManager.EnemyDeathCount)
        {
            FirstDialogue();
        }

        if (CheckLevelEndConditions())
        {
            EndLevel(); 
        }
    }

    private void Start()
    {
        enemyDeathGoal = 12;
        firstDialogueGoal = 6;
        levesStage = 1;

        dialogueManager.AddCharacterImage("Terry", playerTerry);
        dialogueManager.AddCharacterImage("Pharaoh", playerPharaoh);

        BeginLevel();
        dialogueManager.dialogueEnd.AddListener(FirstDialogueOver);
    }

    void BeginLevel()
    {
        StartCoroutine(enemyManager.SpawnEnemy(EnemyType.BasicZombie, spawnerOne, 1));
        StartCoroutine(enemyManager.SpawnEnemy(EnemyType.BasicZombie, spawnerTwo, 1));
        StartCoroutine(enemyManager.SpawnEnemy(EnemyType.BasicZombie, spawnerOne, 3));
        StartCoroutine(enemyManager.SpawnEnemy(EnemyType.BasicZombie, spawnerTwo, 3));
        StartCoroutine(enemyManager.SpawnEnemy(EnemyType.BasicZombie, spawnerOne, 5));
        StartCoroutine(enemyManager.SpawnEnemy(EnemyType.BasicZombie, spawnerTwo, 5));

    }

/*    IEnumerator SpawnEnemy(EnemyType enemyType, GameObject spawner, int interval)
    {
        yield return new WaitForSeconds(interval);
        GameObject enemy = EnemyManager.SpawnEnemy(enemyType, spawner);
        enemy.GetComponent<BasicZombie>().death.AddListener(CountDeath);
    }
*/
    IEnumerator SpawnFirstWave(int interval)
    {
        yield return new WaitForSeconds(interval);
/*        GameObject zombie = EnemyManager.SpawnBasicZombie(spawnerOne);
        zombie.GetComponent<BasicZombie>().death.AddListener(CountDeath);
        GameObject zombie2 = EnemyManager.SpawnBasicZombie(spawnerTwo);
        zombie2.GetComponent<BasicZombie>().death.AddListener(CountDeath);*/
    }


    void FirstDialogue()
    {

        levesStage = 2;
        string[,] dialogue = { 
            { "Terry", "I like elephants and God likes elephants" } , 
            { "Terry", "Whats better than a realistic elephant" },
            { "Terry", "An elephant with blue eyes" },
            { "Pharaoh", "You have seen the truth" },
            { "Pharaoh", "You are welcome in our ranks" },
        };
        dialogueManager.LoadSceneDialogue(dialogue);
        DisplayDialogue();
    }

    void FirstDialogueOver()
    {
        StartCoroutine(enemyManager.SpawnEnemy(EnemyType.BasicZombie, spawnerOne, 1));
        StartCoroutine(enemyManager.SpawnEnemy(EnemyType.BasicZombie, spawnerTwo, 1));
        StartCoroutine(enemyManager.SpawnEnemy(EnemyType.BasicZombie, spawnerOne, 3));
        StartCoroutine(enemyManager.SpawnEnemy(EnemyType.BasicZombie, spawnerTwo, 3));
        StartCoroutine(enemyManager.SpawnEnemy(EnemyType.BasicZombie, spawnerOne, 5));
        StartCoroutine(enemyManager.SpawnEnemy(EnemyType.BasicZombie, spawnerTwo, 5));
    }

    public override bool CheckLevelEndConditions()
    {
        if (enemyManager.EnemyDeathCount >= enemyDeathGoal)
            return true;
        return false;
    }
}
