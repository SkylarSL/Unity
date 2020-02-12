using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlock : MonoBehaviour
{

    public float gravityScaleFactor = 1f;

    void Start()
    {
        //will gradually increase the speed of the falling blocks
        //this is done by, increasing the gravity by the amount of time since the scene has started,
        //at the start of the blocks existence.
        //divide by 20f to decrease the rate at which the block speed up
        GetComponent<Rigidbody2D>().gravityScale += (Time.timeSinceLevelLoad * gravityScaleFactor) / 30f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
    }
}
