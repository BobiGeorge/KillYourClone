using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    BasicZombie,
    Jumper
}

public class EnemyManager : MonoBehaviour
{
    private int enemyDeathCount = 0;
    public int EnemyDeathCount
    {
        get { return enemyDeathCount; }
    }

    public GameObject basicZombie;

    private GameObject SpawnBasicZombie(GameObject spawnPoint)
    {
        GameObject enemy = Instantiate(basicZombie, spawnPoint.transform.position, spawnPoint.transform.rotation);
        enemy.GetComponent<BasicZombie>().death.AddListener(CountDeath);
        return enemy; 
    }

    public IEnumerator SpawnEnemy(EnemyType enemyType, GameObject spawnPoint, int interval)
    {
        yield return new WaitForSeconds(interval);
        switch (enemyType)
        {
            case EnemyType.BasicZombie:
                SpawnBasicZombie(spawnPoint);
                break;
        }
    }

    void CountDeath()
    {
        enemyDeathCount += 1;
    }

}

