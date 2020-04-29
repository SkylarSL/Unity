using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonkyEnemyFunctions : MonoBehaviour
{

    //attributes
    private int moveSpeed;
    private int timeSinceLastMove = 0;
    private float angle;

    //scripts
    public EmberSpawner emberSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time < 136)
        {
            moveSpeed = 2;
        }
        else
        {
            moveSpeed = 4;
        }

        float angleOffset = 101f;
        if (timeSinceLastMove == 1)
        {
            Vector3 dir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        }
        else if (timeSinceLastMove == 60)
        {
            angle = angle + Random.Range(-angleOffset, angleOffset);
        }
        else if(timeSinceLastMove == 120)
        {
            angle = angle + Random.Range(-angleOffset, angleOffset);
        }
        else if(timeSinceLastMove > 180)
        {
            timeSinceLastMove = 0;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        timeSinceLastMove++;


        /*transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.Translate(Vector3.right * 0.5f * Time.deltaTime);*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            emberSpawner.SpawnEmberHigh(0f, 0.4f, transform.position);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            emberSpawner.SpawnEmberMed(0f, 0.4f, transform.position);
            Destroy(gameObject);
        }
    }
}
