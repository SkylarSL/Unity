using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{

    public GameObject gameStartScreen;
    public GameObject storyScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameStartScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReadStory()
    {
        gameStartScreen.SetActive(false);
        storyScreen.SetActive(true);
    }

    public void GoBackFromStory()
    {
        gameStartScreen.SetActive(true);
        storyScreen.SetActive(false);
    }
}
