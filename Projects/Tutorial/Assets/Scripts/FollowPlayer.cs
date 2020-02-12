using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //var type Transform gets the Transform attributes in the UI
    //check Transform for clarity, under any object
    //any object can be dragged into it (in the UI) for reference
    //check MainCamera -> FollowPlayer script for clarity
    public Transform player;

    //var type Vector3 stores 3 floats
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get the position of the referenced object
        //Debug.Log(player.position);

        //"Transform" with lower case "T" refers to the object the script is currently on
        //in this case it is refering to the Main Camera
        //this also sets the Main Camera's position equal to the player's position
        //the offset (which can be specified in the UI thanks to public var)
        //moves the position of the Main Camera slightly so we can ee the player in 3rd person
        transform.position = player.position  + offset;
        

        //NOTE : without an offset you would get a first person view!
    }
}
