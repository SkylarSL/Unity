using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFunctions : MonoBehaviour
{
    private GameManager gm;
    

    public GameObject pauseCanvas;

    private int toggle = 0;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && toggle % 2 == 0)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        toggle++;
        Time.timeScale = 0;
        gm.LoadCanvas(pauseCanvas);
    }

    public void PlayGame()
    {
        toggle++;
        Time.timeScale = 1;
        gm.UnloadCanvas(pauseCanvas);
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        gm.LoadCurrentScene();
    }
    public void ExitGame()
    {
        gm.LoadNextScene();
    }
}
