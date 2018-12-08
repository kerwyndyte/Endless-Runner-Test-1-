using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public CanvasGroup uiElement;

    public IEnumerator currentCoroutine;

    void Start()
	{
		Time.timeScale = 1;
		
        Fadein();

        StartCoroutine(Wait(5));
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(5);
        FadeOut();
    }

    public void Fadein()
    { 
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
		//StartCoroutine(RemoveCanvas(2));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 2.0f)
    {

        float _timeStartLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();

        }
    }

   

	IEnumerator RemoveCanvas(float time)
	{
		yield return new WaitForSeconds(2);
		GameObject.Find ("Disclaimer").SetActive (false);
	}


}
