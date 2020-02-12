using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //NOTE : when an object has an animation, you can trigger a script (like this one) using 
    //"add event" under the Animation tab (its the little pencil and plus sign)
    //making any function in a script, that is attached to an object with an animation, 
    //can be accessed in the Animation Event Inspector tab
    //when the animtion time hits the specified time, it will automatically call the specified function (in this case LoadNextLevel)
    //check the Animation tab and look for a little bar at the 2sec mark and click it for clarity
    public void LoadNextLevel()
    {
        //buildIndex will get the index of the scene
        //index of the scene can be found under File -> Build Settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
