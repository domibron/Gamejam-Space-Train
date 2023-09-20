using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Scene sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnStartgamw()
    {
        SceneManager.LoadScene(sceneToLoad.buildIndex);
    }

    void OnQuitgame()
    {
        Application.Quit();
    }
}
