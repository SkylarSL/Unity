using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //gameobjects
    public GameObject enemy;
    public GameObject wonkyEnemy;
    public GameObject fastEnemy;
    public GameObject hardEnemy;

    //attributes
    private float timeOffset = 0f;
    private float indexedTimeOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad < 105)
        {
            indexedTimeOffset = 2f;
        }
        else
        {
            indexedTimeOffset = 1f;
        }

        if (Time.timeSinceLevelLoad > timeOffset)
        {
            int enemySpawnChance;
            if(Time.timeSinceLevelLoad < 31)
            {
                enemySpawnChance = (int)Random.Range(0f, 10f);
            }
            else if(Time.timeSinceLevelLoad < 76)
            {
                enemySpawnChance = (int)Random.Range(2f, 15f);
            }
            else if(Time.timeSinceLevelLoad < 136)
            {
                enemySpawnChance = (int)Random.Range(5f, 20f);
            }
            else
            {
                enemySpawnChance = (int)Random.Range(7f, 23f);
            }

            if (enemySpawnChance < 10)
            {
                int posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointx = Random.Range(35f, 85f);
                enemySpawnPointx = enemySpawnPointx * posneg;
                posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointy = Random.Range(35f, 85f);
                enemySpawnPointy = enemySpawnPointy * posneg;

                Instantiate(enemy, new Vector3(enemySpawnPointx, enemySpawnPointy, 0), Quaternion.identity);
            }
            else if(enemySpawnChance < 15)
            {
                int posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointx = Random.Range(35f, 85f);
                enemySpawnPointx = enemySpawnPointx * posneg;
                posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointy = Random.Range(35f, 85f);
                enemySpawnPointy = enemySpawnPointy * posneg;

                Instantiate(wonkyEnemy, new Vector3(enemySpawnPointx, enemySpawnPointy, 0), Quaternion.identity);
            }
            else if(enemySpawnChance < 20)
            {
                int posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointx = Random.Range(35f, 85f);
                enemySpawnPointx = enemySpawnPointx * posneg;
                posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointy = Random.Range(35f, 85f);
                enemySpawnPointy = enemySpawnPointy * posneg;

                Instantiate(fastEnemy, new Vector3(enemySpawnPointx, enemySpawnPointy, 0), Quaternion.identity);
            }
            else
            {
                int posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointx = Random.Range(35f, 85f);
                enemySpawnPointx = enemySpawnPointx * posneg;
                posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointy = Random.Range(35f, 85f);
                enemySpawnPointy = enemySpawnPointy * posneg;

                Instantiate(hardEnemy, new Vector3(enemySpawnPointx, enemySpawnPointy, 0), Quaternion.identity);
            }
            timeOffset += indexedTimeOffset;
        }
    }

    
}
