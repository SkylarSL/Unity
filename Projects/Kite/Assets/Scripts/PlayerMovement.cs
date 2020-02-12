using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody player;

    public float movementForce;
    
    public GameManager GM;

    private Queue<Vector3> playerTrail = new Queue<Vector3>();

    public GameObject weapon;

    int frames;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frames++;
        
        if (Input.GetKey("w"))
        {
            player.AddForce(0, 0, movementForce, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            player.AddForce(0, 0, -movementForce, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            player.AddForce(movementForce, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            player.AddForce(-movementForce, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown("space"))
        {
            float playerDashX = player.velocity.x*5;
            float playerDashY = player.velocity.y*5;
            float playerDashZ = player.velocity.z*5;
            player.AddForce(playerDashX, playerDashY, playerDashZ, ForceMode.VelocityChange);
        }
        else
        {
            player.velocity = Vector3.zero;
        }

        PastMovement();
        if(frames > 50)
        {
            moveWeapon();
        }
       
        
    }

    private void moveWeapon()
    {
        
        Vector3 pastPos = playerTrail.Dequeue();
        //Debug.Log(pastPos);
        weapon.transform.LookAt(pastPos);
        weapon.transform.position += weapon.transform.forward * 10 * Time.deltaTime;
    }

    private void PastMovement()
    {
        Vector3 playerCurrentPosition;
        float playerXCoord = player.position.x;
        float playerZCoord = player.position.z;
        playerCurrentPosition = new Vector3(playerXCoord, 0f, playerZCoord);
        playerTrail.Enqueue(playerCurrentPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.collider.name == "Weapon")
        {
            //will ignore collisions between player and weapon
            //first argument is weapon (specified object), and second agument is player (this)
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            //Debug.Log("HIT");
        }
        



        if(collision.collider.tag == "Enemy")
        {
            //Debug.Log("BITTEN");
            GM.GameOver();
        }
    }
}
