using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{

    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        float randomX = Random.Range(-12, 12);
        float randomY = Random.Range(-12, 12);
        Vector2 position = new Vector2(randomX, randomY);
        Instantiate(point, position, Quaternion.identity);
    }
}
