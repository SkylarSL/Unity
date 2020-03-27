using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkSpawner : MonoBehaviour
{

    public GameObject spark;
    int spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > spawnTimer)
        {
            Spawn();
            spawnTimer += 3;
        }
    }

    public void Spawn()
    {
        float randomX = Random.Range(-12, 12);
        float randomY = Random.Range(-12, 12);
        Vector2 position = new Vector2(randomX, randomY);
        Instantiate(spark, position, Quaternion.identity);
    }
}
