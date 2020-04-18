using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberSpawner : MonoBehaviour
{
    //gameobjects
    public GameObject ember;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnEmberLow(float innerRadius, float outerRadius, Vector3 pos)
    {
        int emberSpawnChance = (int)Random.Range(0f, 4f);
        if (emberSpawnChance == 0)
        {
            int posneg = (int)Random.Range(0, 2) * 2 - 1;
            float emberSpawnPointx = Random.Range(innerRadius, outerRadius);
            emberSpawnPointx = (emberSpawnPointx * posneg);
            posneg = (int)Random.Range(0, 2) * 2 - 1;
            float emberSpawnPointy = Random.Range(innerRadius, outerRadius);
            emberSpawnPointy = emberSpawnPointy * posneg;
            Vector3 spawnPointInCircle = new Vector3(emberSpawnPointx, emberSpawnPointy, 0);
            Vector3 spawnPoint = spawnPointInCircle + pos;
            Instantiate(ember, spawnPoint, Quaternion.identity);
        }
    }

    public void SpawnEmberMed(float innerRadius, float outerRadius, Vector3 pos)
    {
        int emberSpawnChance = (int)Random.Range(0f, 3f);
        if (emberSpawnChance == 0)
        {
            int posneg = (int)Random.Range(0, 2) * 2 - 1;
            float emberSpawnPointx = Random.Range(innerRadius, outerRadius);
            emberSpawnPointx = (emberSpawnPointx * posneg);
            posneg = (int)Random.Range(0, 2) * 2 - 1;
            float emberSpawnPointy = Random.Range(innerRadius, outerRadius);
            emberSpawnPointy = emberSpawnPointy * posneg;
            Vector3 spawnPointInCircle = new Vector3(emberSpawnPointx, emberSpawnPointy, 0);
            Vector3 spawnPoint = spawnPointInCircle + pos;
            Instantiate(ember, spawnPoint, Quaternion.identity);
        }
    }

    public void SpawnEmberHigh(float innerRadius, float outerRadius, Vector3 pos)
    {
        int emberSpawnChance = (int)Random.Range(0f, 2f);
        if (emberSpawnChance == 0)
        {
            int posneg = (int)Random.Range(0, 2) * 2 - 1;
            float emberSpawnPointx = Random.Range(innerRadius, outerRadius);
            emberSpawnPointx = (emberSpawnPointx * posneg);
            posneg = (int)Random.Range(0, 2) * 2 - 1;
            float emberSpawnPointy = Random.Range(innerRadius, outerRadius);
            emberSpawnPointy = emberSpawnPointy * posneg;
            Vector3 spawnPointInCircle = new Vector3(emberSpawnPointx, emberSpawnPointy, 0);
            Vector3 spawnPoint = spawnPointInCircle + pos;
            Instantiate(ember, spawnPoint, Quaternion.identity);
        }
    }
}
