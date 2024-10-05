using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitFeedback : Feedback
{
    [SerializeField] private float _duration;
    [SerializeField] private Color _hitColor;
    [SerializeField] ParticleSystem particle;
    private Image _enemyImage;

    private void Awake()
    {
        _enemyImage = GetComponent<Image>();
    }

    public override void PlayFeedback()
    {
        StartCoroutine(HitFeedbackCoroutine());
    }

    private IEnumerator HitFeedbackCoroutine()
    {
        float currentTime = 0;

        particle.Play();

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
