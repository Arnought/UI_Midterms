using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private bool onClick = false;
    public float duration;
    public Image image;
    private Vector3 originalPos, shake, bounce, flip;

    public void Start()
    {
        shake = new Vector3(15, 0, 0);
        bounce = new Vector3(0, 15, 0);
        flip = new Vector3(0, 180, 0);
    }

    public void Zoom()
    {
        float zoomVal = 0;
        float targetScale = onClick ? 1.0f : zoomVal;
        image.transform.DOScale(targetScale, 0.25f);
        onClick = !onClick;
    }

    public void Fade() 
    {
        float fadeVal = 0;
        float targetFade = onClick ? 1.0f : fadeVal;
        image.DOFade(targetFade, 0.25f);
        onClick = !onClick;

    }

    public void Shake()
    {
        float shakeVal = 2;
        float shakeSTR = 1;
        float targetShake = onClick ? 1.0f : shakeVal;
        image.transform.DOShakePosition(targetShake, shake, 20, shakeSTR, true, true, ShakeRandomnessMode.Harmonic);
        onClick = !onClick;
    }

    public void Bounce()
    {
        float bounceVal = 1;
        float elasticity = 1;
        float targetBounce = onClick ? 1.0f : bounceVal;
        image.transform.DOPunchPosition(bounce, targetBounce, 30, elasticity, false).SetEase(Ease.OutBounce);
        onClick = !onClick;
    }

    public void Scale() 
    {
        float scaleVal = 0.9f;
        float targetScale = onClick ? 1.0f : scaleVal;
        image.DOFade(0, duration);
        image.transform.DOScale(targetScale, 0.25f).SetEase(Ease.Linear);
        onClick = !onClick;
        if(!onClick)
        {
            image.DOFade(1, duration);
        }
    }

    public void Flip()
    {
        float flipVal = 0;
        float targetFlip = onClick ? 1.0f : flipVal;
        image.transform.DORotate(flip, duration);
        onClick = !onClick;
        if(!onClick)
        {
            image.transform.DORotate(originalPos, duration);
        }
    }
}
