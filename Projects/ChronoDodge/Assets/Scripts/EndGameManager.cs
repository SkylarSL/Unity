using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{

    public GameObject creditsScreen;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ASDF");
        creditsScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
