using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    //by making a public variable, you can update this variable in the UI
    //check Player -> PlayeMovement script for clarity
    public float fowardForce = 2000f;
    public float sidewaysForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
        //will output a message in the console
        //Debug.Log("Hello");

        //will turn the gravity on for the rigidbody
        //rigibody (rb) is refering to the object you drag into it in the UI
        //check the Player -> PlayerMovement script in user interface for clarity
        rb.useGravity = true;
        
        //adds a force to said object (rb)
        //rb.AddForce(0, 0, 500);
    }

    // Update is called once per frame
    //Unity likes using FixedUpdate rather than Update
    void FixedUpdate()
    {
        //Time.deltaTime : evens out the force depending on frame rate
        //ie more fps means smaller Time and less fps larger Time
        rb.AddForce(0, 0, fowardForce * Time.deltaTime, ForceMode.VelocityChange);

        //add force only if a certain key is pressed (on keyboard)
        //4th parameter "ForceMode" specifies the type of force to add
        //in this case, we are adding velocity to make the object more responsive to user input
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //when the player falls off the edge, call endGame in GameManager script
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().endGame();
        }
    }
}










//recommened way to handle movements below, but not necessary for this type of game
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    //by making a public variable, you can update this variable in the UI
    //check Player -> PlayeMovement script for clarity
    public float fowardForce = 2000f;
    public float sidewaysForce = 500f;

    //store booleans for movement
    public bool moveRight = false;
    public bool moveLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        //will output a message in the console
        Debug.Log("Hello");

        //will turn the gravity on for the rigidbody
        //rigibody (rb) is refering to the object you drag into it in the UI
        //check the Player -> PlayerMovement script in user interface for clarity
        rb.useGravity = true;

        //adds a force to said object (rb)
        //rb.AddForce(0, 0, 500);
    }

    // Update is called once per frame
    //Unity likes using FixedUpdate rather than Update
    void FixedUpdate()
    {
        //Time.deltaTime : evens out the force depending on frame rate
        //ie more fps means smaller Time and less fps larger Time
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);

        //change movement bools appropriately
        if (Input.GetKey("D"))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }
        if (Input.GetKey("A"))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }

        //add forces if certain movement bool is true
        if (moveRight)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (moveLeft)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
    }
}
*/