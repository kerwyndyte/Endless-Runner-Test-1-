using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public static bool GameisPaused = false;

    public void PlayGame()
    {
        SceneManager.LoadScene("TestZone");
    }

   

    public void QuitGame()
    {
        Application.Quit();
    }
}
