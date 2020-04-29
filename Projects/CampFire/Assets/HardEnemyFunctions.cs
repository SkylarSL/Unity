using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemyFunctions : MonoBehaviour
{
    //rigibodies
    public Rigidbody2D rb;

    //attributes
    private int lifePoints = 3;
    private float moveSpeed = 2f;

    //scripts
    public EmberSpawner emberSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.zero;
        Vector3 dir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        if (lifePoints <= 0)
        {
            emberSpawner.SpawnEmberHigh(0f, 0.4f, transform.position);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            lifePoints--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            lifePoints--;
        }
    }
}
