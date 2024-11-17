using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool FadeIn = false;
    public bool FadeOut = false;
    public float FadeSpeed = 1.0f;

    // Copy-Paste no mne vpadlu visovivatj eto iz Update, optimizacija potom :))
    void Update()
    {
        if (FadeIn)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += FadeSpeed * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    FadeIn = false;
                }
            }
        }
        else if (FadeOut)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= FadeSpeed * Time.deltaTime;
                if (canvasGroup.alpha <= 0)
                {
                    FadeOut = false;
                }
            }
        }
        
    }

    public void StartFadeIn()
    {
        FadeIn = true;
    }

    public void StartFadeOut()
    {
        FadeOut = true;
    }   
}
