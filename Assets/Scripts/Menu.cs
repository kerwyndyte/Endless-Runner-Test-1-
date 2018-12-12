using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Text highscoreText;

    private void Start()
    {
        highscoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
    }


    public void PlayGame()
    {
        StartCoroutine(WaitforFade(2));
    }

    IEnumerator WaitforFade(float time)
    {
        yield return new WaitForSeconds(4);
        Load();
    }

    public void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
