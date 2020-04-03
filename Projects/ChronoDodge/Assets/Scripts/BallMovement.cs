using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*int ballType = (int)Random.Range(0f, 10f);
        Vector3 dir = new Vector3(0, 1, 0);
        if (ballType == 1)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up*100, ForceMode2D.Force);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 2, ForceMode2D.Force);
        }*/
        int currentSpark = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>().GetCurrentSpark();
        if (Input.GetKeyDown("k") && currentSpark == 5)
        {
            Debug.Log("ASDF");
            Vector2 pos1 = gameObject.transform.position;
            Vector2 pos2 = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector2 dir = pos2 - pos1;
            float scalarDir = Mathf.Sqrt((dir.x) * (dir.x) + (dir.y) * (dir.y));
            dir = (-dir) * (10/scalarDir);
            rb.AddForce(dir, ForceMode2D.Impulse);
        }

        if(transform.position.x < -12 
            || transform.position.x > 12
            || transform.position.y < -12
            || transform.position.y > 12)
        {
            Destroy(gameObject);
        }
    }
}
