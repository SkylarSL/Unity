using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverFunctions : MonoBehaviour
{

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameManager") != null)
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetGame()
    {
        gm.LoadCurrentScene();
    }
    public void ExitGame()
    {
        gm.LoadNextScene();
    }
}
