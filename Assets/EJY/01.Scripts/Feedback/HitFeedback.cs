using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitFeedback : Feedback
{
    [SerializeField] private float _duration;
    [SerializeField] private Color _hitColor;
    private Image _enemyImage;

    private void Awake()
    {
        _enemyImage = FindObjectOfType<Image>().GetComponent<Image>();
    }

    public override void PlayFeedback()
    {
        StartCoroutine(HitFeedbackCoroutine());
    }

    private IEnumerator HitFeedbackCoroutine()
    {
        float currentTime = 0;

        while (currentTime < _duration)
        {
            currentTime += Time.deltaTime;

            _enemyImage.color = Color.Lerp(Color.white, _hitColor, currentTime / _duration);

            yield return null;
        }

        currentTime = 0;

        while (currentTime < _duration)
        {
            currentTime += Time.deltaTime;

            _enemyImage.color = Color.Lerp(_hitColor, Color.white, currentTime / _duration);

            yield return null;
        }
    }

    public override void StopFeedback()
    {
        StopAllCoroutines();
    }
}
