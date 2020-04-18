using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberFunctions : MonoBehaviour
{

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce((Vector3.zero - gameObject.transform.position), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown("e"))
        {
            explosion.SetActive(true);
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    
}
