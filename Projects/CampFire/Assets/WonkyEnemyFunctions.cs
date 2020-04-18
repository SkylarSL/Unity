using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonkyEnemyFunctions : MonoBehaviour
{

    //attributes
    private float moveSpeed = 1;

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
        float angleOffset = 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.Translate(Vector3.right * 0.0005f * Time.deltaTime);
        angle = angle + Random.Range(-angleOffset, angleOffset);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.Translate(Vector3.right * 2 * Time.deltaTime);
        angle = angle + Random.Range(-angleOffset, angleOffset);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.Translate(Vector3.right * 2 * Time.deltaTime);
        angle = angle + Random.Range(-angleOffset, angleOffset);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.Translate(Vector3.right * 2 * Time.deltaTime);
        angle = angle + Random.Range(-angleOffset, angleOffset);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.Translate(Vector3.right * 2 * Time.deltaTime);

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
