using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyFunctions : MonoBehaviour
{

    //attributes
    private float moveSpeed = 10f;

    //scripts
    public EmberSpawner emberSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
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
