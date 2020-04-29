using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameFunctions : MonoBehaviour
{
    //scripts
    private GameManager gm;

    //canvas
    public GameObject startCanvas;
    public GameObject tutCanvas;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void LoadGame()
    {
        gm.LoadNextScene();
    }

    public void ExitGame()
    {
        gm.ExitGame();
    }

    public void ShowTutorial()
    {
        gm.UnloadCanvas(startCanvas);
        gm.LoadCanvas(tutCanvas);
    }

    public void ShowTitleScreen()
    {
        gm.UnloadCanvas(tutCanvas);
        gm.LoadCanvas(startCanvas);
    }
}
