﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

    public static bool GameisPaused = false;
       

    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }

   

    public void QuitGame()
    {
        Application.Quit();
    }
}
