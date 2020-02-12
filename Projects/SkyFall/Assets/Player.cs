using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 15f;

    //choose how wide the map will be
    public float mapBoundary = 5f;

    //doesn't have to be public because of how we are assigning the variable
    private Rigidbody2D rb;

    public GameManager gm;

    private void Start()
    {
        //cache this
        //automatically finds the component and put it into the variable
        //in this case finds Rigidbody2D
        //same as doing "public Rigidbody2D rb;" and dragging the Rigibody2D into the slot in the GUI
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //fetches form unity if the user pressed move right or left
        //gets value between -1 and 1, translates to movement
        float x = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

        //Vector2.right or Vector2.left means to move in the horizontal axis
        //we multiply by x for opposite movement and speed of movement
        Vector2 newPosition = rb.position + Vector2.right * x;

        //this will create boundaries on the map so the player is restricted right or left
        //takes the current position (newPosition.x) and ensures it doesn't go past -mapBoundary and mapBoundary
        newPosition.x = Mathf.Clamp(newPosition.x, -mapBoundary, mapBoundary);

        //moves the object to the position checking for collision along the way
        rb.MovePosition(newPosition);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //don't do this because there could be multiple objects of type GameManager
        //not performant either
        //FindObjectOfType<GameManager>().EndGame();

        gm.EndGame();
    }
}
