using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;


    public void StartLoad()
    {
        StartCoroutine(WaitforFade(4));
    }

    IEnumerator WaitforFade(float time)
    {
        yield return new WaitForSeconds(4);
        Load(1);
    }

    public void Load (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
	}

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }
}
