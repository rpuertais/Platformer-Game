using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void OnClick(int levelValue)
    {
        SceneManager.LoadScene(levelValue);
    }
    public void OnEscape()
    {
        Application.Quit();
        //Debug.Log("Estas out del juego");
    }
}
