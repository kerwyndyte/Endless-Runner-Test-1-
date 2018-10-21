using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {

    public static bool GameisPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseButton()
    {
        if (GameisPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
