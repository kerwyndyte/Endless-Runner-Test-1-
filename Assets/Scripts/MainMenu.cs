using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
       

    public void PlayGame()
    {
        StartCoroutine(WaitforFade(4));
    }

    IEnumerator WaitforFade(float time)
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	

    public void QuitGame()
	{
		Application.Quit ();
	}
}
