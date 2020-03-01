using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] ballSpawner;

    private int numOfBallSpawners;

    public GameObject ball;

    public float spawnRate;

    public float timeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        numOfBallSpawners = ballSpawner.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToSpawn)
        {
            Spawn();
            timeToSpawn = Time.time + spawnRate;
        }

    }

    private void Spawn()
    {

        int spawnIndex = (int)Random.Range(0f, 91f);

        int angleOffset = (int)Random.Range(-20f, 20f);

        string ballType = ballSpawner[spawnIndex].tag;

        if (ballType == "top")
        {
            GameObject ballSpeed = Instantiate(ball, ballSpawner[spawnIndex].transform.position, Quaternion.Euler(0, 0, 180 + angleOffset));
            if(angleOffset == 0)
            {
                ballSpeed.GetComponent<Rigidbody2D>().AddForce(ballSpeed.transform.up * 500, ForceMode2D.Force);
            }
            else
            {
                ballSpeed.GetComponent<Rigidbody2D>().AddForce(ballSpeed.transform.up * 150, ForceMode2D.Force);
            }
        }
        else if (ballType == "right")
        {
            GameObject ballSpeed = Instantiate(ball, ballSpawner[spawnIndex].transform.position, Quaternion.Euler(0, 0, 90 + angleOffset));
            if (angleOffset == 0)
            {
                ballSpeed.GetComponent<Rigidbody2D>().AddForce(ballSpeed.transform.up * 500, ForceMode2D.Force);
            }
            else
            {
                ballSpeed.GetComponent<Rigidbody2D>().AddForce(ballSpeed.transform.up * 150, ForceMode2D.Force);
            }
        }
        else if (ballType == "bot")
        {
            GameObject ballSpeed = Instantiate(ball, ballSpawner[spawnIndex].transform.position, Quaternion.Euler(0, 0, 0 + angleOffset));
            if (angleOffset == 0)
            {
                ballSpeed.GetComponent<Rigidbody2D>().AddForce(ballSpeed.transform.up * 500, ForceMode2D.Force);
            }
            else
            {
                ballSpeed.GetComponent<Rigidbody2D>().AddForce(ballSpeed.transform.up * 150, ForceMode2D.Force);
            }
        }
        else if (ballType == "left")
        {
            GameObject ballSpeed = Instantiate(ball, ballSpawner[spawnIndex].transform.position, Quaternion.Euler(0, 0, -90 + angleOffset));
            if (angleOffset == 0)
            {
                ballSpeed.GetComponent<Rigidbody2D>().AddForce(ballSpeed.transform.up * 500, ForceMode2D.Force);
            }
            else
            {
                ballSpeed.GetComponent<Rigidbody2D>().AddForce(ballSpeed.transform.up * 150, ForceMode2D.Force);
            }
        }
        else
        {
            //do nothing
        }
    }
}
