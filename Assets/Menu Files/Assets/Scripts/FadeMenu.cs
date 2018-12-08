using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeMenu : MonoBehaviour
{
    public CanvasGroup UIElement;

    public IEnumerator currentCoroutine;

    public void MenuFadein()
    {
        StartCoroutine(FadeCanvas(UIElement, UIElement.alpha, 1));
    }

    public void MenuFadeOut()
    {
        StartCoroutine(FadeCanvas(UIElement, UIElement.alpha, 0));
    }

    public IEnumerator FadeCanvas(CanvasGroup cg, float start, float end, float lerpTime = 2.0f)
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






}
