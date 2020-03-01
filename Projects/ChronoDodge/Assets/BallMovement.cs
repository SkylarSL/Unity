using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
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
       

        if(transform.position.x < -12 
            || transform.position.x > 12
            || transform.position.y < -12
            || transform.position.y > 12)
        {
            Destroy(gameObject);
        }
    }
}
