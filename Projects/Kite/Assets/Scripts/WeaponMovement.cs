using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMovement : MonoBehaviour
{
    //get the player's gme object for position
    public GameObject playerPos;

    //get the weapon's position
    public Transform weaponPos;

    //get the weapon's physics
    public Rigidbody weaponMovement;

    //get the score
    public Text scoreUI;

    private int scoreNum;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //good concept, this creates more of a weapon though, keep in mind for later possible 2 player game
        //try this code out for clarity
        /*
        Vector3 moveTowards = playerPos.transform.position - weaponPos.position;
        weaponMovement.AddForce(moveTowards.x, moveTowards.y, moveTowards.z, ForceMode.VelocityChange);
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            //scoreNum++;
            //IncrementScore(scoreNum);
        }
    }

    private void IncrementScore(int score)
    {
        scoreUI.text = score.ToString();
    }
}
