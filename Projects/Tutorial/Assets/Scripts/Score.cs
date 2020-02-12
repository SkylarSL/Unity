using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//library for UI elements
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //adds a reference to the Transormation information of the specified object
    public Transform player;

    //adds referece to the Text information of specified object
    //in this case the text from the score object (UI)
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //scoreTest.text lets you modify the text of the specified object
        //player.position.z gets the z position of the specified object
        scoreText.text = player.position.z.ToString("0");
    }
}

//NOTE : you "specify" objects by draggin them into the reference boxes, under the scripts, in the Unity UI
