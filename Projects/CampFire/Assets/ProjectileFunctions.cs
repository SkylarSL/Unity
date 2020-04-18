using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFunctions : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject explosion;
    public EmberSpawner emberSpawner;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        float xDis = mousePos.x;
        float yDis = mousePos.y;
        float angle = Mathf.Atan2(yDis, xDis) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        rb.AddForce(mousePos, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.position.x > 30 || rb.position.x < -30 || rb.position.y > 30 || rb.position.y < -30)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown("q"))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if(hit.collider == null || hit.collider.tag != "Ember")
            {
                rb.velocity = Vector3.zero;
                Vector3 forceDir = new Vector3(mousePos.x, mousePos.y) - transform.position;
                float angle = Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
                rb.AddForce(forceDir, ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            explosion.SetActive(true);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
