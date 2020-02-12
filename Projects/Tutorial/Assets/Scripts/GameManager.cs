using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//need to include this when changing the scene of the game
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //add a boolean so the game ends only once, untill the scene has been restarted
    bool gameHasEnded = false;

    //bool for amount of time untill game restarts
    public float restartDelay = 1f;

    //get a reference to the "LEVEL Complete" UI (named LevelComplete)
    public GameObject completeLevelUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");

            //Restart the game instantly
            //restart();

            //add a light delay
            //takes in "name of function" (string type) and amount of time (float type)
            Invoke("restart", restartDelay);
        }
        
    }

    void restart()
    {
        //load the scene that is named "Level01"
        //SceneManager.LoadScene("Level01");

        //SceneManager.GetActiveScene().name returns the name of the current scene
        //SceneManager.LoadScene loads the specified scene by name (string type)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    public void completeLevel()
    {
        Debug.Log("COMPLETED");
        completeLevelUI.SetActive(true);
    }
}
