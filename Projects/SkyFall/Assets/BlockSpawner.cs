using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;

    public GameObject blockObject;

    public float spawnRate = 2f;

    private float timeToSpawn = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //amount of seconds that have passed since the game has started
        //this is like a global constant variable
        //Time.time

        if(Time.time >= timeToSpawn)
        {
            SpawnBlocks();

            //increase timeToSpawn so every "spawnRate" seconds a wave will spawn
            timeToSpawn = Time.time + spawnRate;
        }

    }

    void SpawnBlocks()
    {
        int len = spawnPoints.Length;

        //get a random number between the spawn points
        //choose a spawn point to not spawn a block on
        int randomIndex = Random.Range(0, len);

        Vector3 offset = new Vector3(0, 0, 2);

        for (int i = 0; i < len; i++)
        {
            //create a block when not equal to i
            if (randomIndex != i)
            {
                Instantiate(blockObject, spawnPoints[i].position + offset, Quaternion.identity);
            }
        }
    }
}
