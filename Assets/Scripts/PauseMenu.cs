using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool GameisPaused = false;

    public GameObject pauseMenuUI;

    public void Start()
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

    public void BacktoMenuGame()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
