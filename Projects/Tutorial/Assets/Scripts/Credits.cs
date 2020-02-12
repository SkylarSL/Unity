using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this function becomes public for the button
    //functions must be public for the button to access it through the "On Click ()" UI under
    //"Button (script)" tab, under the button object
    //now, this function will be called when the button is clicked
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
