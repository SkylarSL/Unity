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
    private int timeOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > timeOffset)
        {
            int enemySpawnChance = (int)Random.Range(0f, 10f);

            if(enemySpawnChance < 6)
            {
                int posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointx = Random.Range(35f, 85f);
                enemySpawnPointx = enemySpawnPointx * posneg;
                posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointy = Random.Range(35f, 85f);
                enemySpawnPointy = enemySpawnPointy * posneg;

                Instantiate(enemy, new Vector3(enemySpawnPointx, enemySpawnPointy, 0), Quaternion.identity);
                timeOffset += 1;
            }
            else if(enemySpawnChance >=6 && enemySpawnChance < 8)
            {
                int posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointx = Random.Range(35f, 85f);
                enemySpawnPointx = enemySpawnPointx * posneg;
                posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointy = Random.Range(35f, 85f);
                enemySpawnPointy = enemySpawnPointy * posneg;

                Instantiate(wonkyEnemy, new Vector3(enemySpawnPointx, enemySpawnPointy, 0), Quaternion.identity);
                timeOffset += 1;
            }
            else if(enemySpawnChance >= 8 && enemySpawnChance < 9)
            {
                int posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointx = Random.Range(35f, 85f);
                enemySpawnPointx = enemySpawnPointx * posneg;
                posneg = (int)Random.Range(0, 2) * 2 - 1;
                float enemySpawnPointy = Random.Range(35f, 85f);
                enemySpawnPointy = enemySpawnPointy * posneg;

                Instantiate(fastEnemy, new Vector3(enemySpawnPointx, enemySpawnPointy, 0), Quaternion.identity);
                timeOffset += 1;
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
                timeOffset += 1;
            }
            
        }
    }

    
}
