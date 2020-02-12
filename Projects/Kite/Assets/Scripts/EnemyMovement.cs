using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //get the player's gme object for position
    //public GameObject playerPos;

    //set the movement speed of the enemy
    public int movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //good concept, this creates more of a weapon though, keep in mind for later possible 2 player game
        //try this code out for clarity
        //Vector3 moveTowards = playerPos.transform.position - enemyPos.position;
        //enemyMovement.AddForce(moveTowards.x, moveTowards.y, moveTowards.z, ForceMode.VelocityChange);

        //get any game object with the tag "Player"

        //GameObject playerPos = GameObject.FindWithTag("Player");

        //make the current object look at the specified game objects transform
        //essentially rotates the current object to look at the specified object
        //transform.LookAt(playerPos.transform);

        //adds to the position of the current object in the direction of the specified object
        //moves the object foward, and towards the specified object
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Weapon" || collision.collider.tag == "Enemy")
        {
            //Debug.Log("DEAD");
            //Destroy(gameObject, 0);
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
