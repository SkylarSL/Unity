using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFunctions : MonoBehaviour
{
    //attributes
    private float timeTillDeath;

    // Start is called before the first frame update
    void Start()
    {
        timeTillDeath = Time.timeSinceLevelLoad + 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad > timeTillDeath)
        {
            Destroy(gameObject);
        }
    }
}
