using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public bool isLoading = false;
    public static ChangeScene instance { get; private set; }

    int sceneIndex;
    int thislevel;
    int lastScene;

    void Awake()
    {
        if (instance != null)
        {
            instance.thislevel = SceneManager.GetActiveScene().buildIndex;
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        isLoading = false;

        thislevel = SceneManager.GetActiveScene().buildIndex;
        lastScene = SceneManager.sceneCountInBuildSettings;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdvanceCustomLevel(int level)
    {
        if (!isLoading)
        {
            isLoading = true;
            SceneManager.LoadScene(level);
        }
        isLoading = false;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Estas out del juego");
    }

}
