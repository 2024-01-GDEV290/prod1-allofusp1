using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavenQuest : MonoBehaviour
{

    public GameObject questText;
    public float beginTime = 2.0f;
    public float activeTime = 30.0f;
    public float fadeDuration = 2.0f;

    private CanvasGroup questTextCanvasGroup;

    void Start()
    {
        questTextCanvasGroup = questText.GetComponent<CanvasGroup>();
        if (questTextCanvasGroup != null)
        {
            questTextCanvasGroup.alpha = 0; // Make sure text is invisible at start
            StartCoroutine(DisplayQuest());
        }
    }

    IEnumerator DisplayQuest()
    {
        yield return new WaitForSeconds(beginTime);
        //questText.SetActive(true);
        yield return StartCoroutine(FadeTextTo(1.0f)); // Fade in
        yield return new WaitForSeconds(activeTime);
        yield return StartCoroutine(FadeTextTo(0.0f)); // Fade out
        //questText.SetActive(false);
    }

    IEnumerator FadeTextTo(float targetAlpha)
    {
        float alpha = questTextCanvasGroup.alpha;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeDuration)
        {
            questTextCanvasGroup.alpha = Mathf.Lerp(alpha, targetAlpha, t);
            yield return null;
        }

        questTextCanvasGroup.alpha = targetAlpha;
    }
}
