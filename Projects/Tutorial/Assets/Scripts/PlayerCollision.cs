using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    //adds reference to the PlayerMovement script
    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Specified function for collisions
    private void OnCollisionEnter(Collision collision)
    {
        //will display the name of what ever you hit
        Debug.Log(collision.collider.name);

        //NOTE : checking name is not the best way
        //use tags instead, tags are used to group objects together
        //tage is under object's name
        
        //if the player hits something, stop the movement script
        if(collision.collider.tag == "Obsticle")
        {
            pm.enabled = false;
            //below does the exact same thing as above
            //GetComponent<PlayerMovement>().enabled = false;

            //finds the object of the specified type, in the case GameManager
            //this is used to call other function in different scripts
            //check GameManager script for clarity
            FindObjectOfType<GameManager>().endGame();

        }
    }
}



//to create a prefab, simply drag the object you want to make a prefab of into the assets section
//prefabs are used when you want multiple objects of the same type