using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameEndScreen;
    public GameObject resourceScreen;
    public GameObject scoreScreen;

    public Text scorePanel;

    private int score;
    private int increaseScoreOffset = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("ADSF");
        score = 0;
        scoreScreen.SetActive(true);
        resourceScreen.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad > increaseScoreOffset && !gameEndScreen.active)
        {
            IncrementPoints();
            increaseScoreOffset++;
        }
    }

    public void ActivateResetGame()
    {
        gameEndScreen.SetActive(true);
        gameEndScreen.active = true;
        Time.timeScale = 0.25f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        scoreScreen.SetActive(false);
        resourceScreen.SetActive(false);
        gameEndScreen.SetActive(false);
        SceneManager.LoadScene("EndGame");
    }

    public void IncrementPoints()
    {
        score++;
        scorePanel.text = score.ToString();
    }

}
