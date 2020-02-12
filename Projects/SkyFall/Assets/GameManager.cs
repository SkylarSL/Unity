using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float slowness = 10f;
    public void EndGame()
    {
        //a coroutine is like a function that has the ablity to pause execution
        //then return control to Unity, but then continue where is left off on the following frame
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        //time will move slower of faster depending on the value,  between 0-1
        //default value of 1
        Time.timeScale = 1f / slowness;

        //must also change FixedUpdate()
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        //before 1 sec

        //WaitForSeconds is also affected by the time slow, must divide by slowness to get the exp of 1 sec
        //will wait for 1 second and then call the code below
        yield return new WaitForSeconds(1f / slowness);

        //after 1 sec

        //must set the time back to normal ater slowing it down
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        //GetActiveScene will load the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
