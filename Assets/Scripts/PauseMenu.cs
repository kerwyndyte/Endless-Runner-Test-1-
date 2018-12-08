using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool GameisPaused = false;

    public GameObject pauseMenuUI;

    public GameObject countdown3;
    public GameObject countdown2;
    public GameObject countdown1;

    public Text txtCountdown;

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
        // StartCoroutine (Countdown(3));
        GameisPaused = false;
    }

    /*IEnumerator Countdown(float pauseDuration)
    {
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        txtCountdown.gameObject.SetActive(true);
        txtCountdown.text = "3";
        yield return new WaitForSeconds(1f);
        txtCountdown.text = "2";
        yield return new WaitForSeconds(1f);
        txtCountdown.text = "1";
        yield return new WaitForSeconds(1f);
        txtCountdown.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;


    }*/

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
