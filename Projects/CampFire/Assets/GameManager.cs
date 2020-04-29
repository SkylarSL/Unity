using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        LoadNextScene();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        currentScene++;
        SceneManager.LoadScene(currentScene);
    }

    public void LoadPrevScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        currentScene--;
        SceneManager.LoadScene(currentScene);
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadCanvas(GameObject canvas)
    {
        canvas.SetActive(true);
    }

    public void UnloadCanvas(GameObject canvas)
    {
        canvas.SetActive(false);
    }

    public void GameOver()
    {
        GameObject.Find("PlayerAppearance").GetComponent<PlayerFunctions>().enabled = false;
        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().enabled = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyFunctions>().enabled = false;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
