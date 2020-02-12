using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Transform spawnLocation;

    public GameObject Enemy;

    public float spawnTimer;

    public float timeToFirstSpawn;

    public string dir;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating(string spawnItem, float timeTillFirstInvoke, float invokeRate);
        InvokeRepeating("Spawner", timeToFirstSpawn, spawnTimer);

    }

    private void Spawner()
    {
        //get the position of the spawner, in this case the wall
        float spawnPointX = spawnLocation.position.x;
        float spawnPointY = spawnLocation.position.y;
        float spawnPointZ = spawnLocation.position.z;
        float xOffset = 0, zOffset = 0;
        if(spawnPointX == 25 || spawnPointX == -25)
        {
            float zScale = spawnLocation.localScale.z;
            float zOffsetRange = zScale / 2;
            //Debug.Log(zOffset);
            zOffset = Random.Range(-zOffsetRange, zOffsetRange);
        }
        else if (spawnPointZ == -25 || spawnPointZ == 25)
        {
            float xScale = spawnLocation.localScale.x;
            float xOffsetRange = xScale / 2;
            xOffset = Random.Range(-xOffsetRange, xOffsetRange);
        }

        //set the spawn point
        Vector3 spawnPoint = new Vector3(spawnPointX+xOffset, spawnPointY, spawnPointZ+zOffset);

        GameObject e = Instantiate(Enemy, spawnPoint, Quaternion.identity);
        if(dir == "right")
        {
            GameObject wall = GameObject.Find("RightWall");
            Debug.Log(e.transform);
            e.transform.LookAt(wall.transform);
        }
        else if (dir == "left")
        {
            GameObject wall = GameObject.Find("LeftWall");
            e.transform.LookAt(wall.transform);
        }
        else if(dir == "down")
        {
            GameObject wall = GameObject.Find("BotWall");
            e.transform.LookAt(wall.transform);
        }
        else
        {
            GameObject wall = GameObject.Find("TopWall");
            e.transform.LookAt(wall.transform);
        }
        //Debug.Log("(" + spawnPointX + ", " + spawnPointY + ", " + spawnPointZ + ")");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
