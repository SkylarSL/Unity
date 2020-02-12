using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    //add a reference to the Game Manager to access completeLevel function
    public GameManager gameManager;

    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //anoter way of checking collisions
    //checks a trigger function
    //must check "Is Trigger" under Box Collider component for the object you want to trigger on
    //NOTE : when "Is Trigger" is checked, the object can not be physically hit (collided), 
    //it becomes a "trigger"
    private void OnTriggerEnter(Collider other)
    {
        gameManager.completeLevel();
    }
}
