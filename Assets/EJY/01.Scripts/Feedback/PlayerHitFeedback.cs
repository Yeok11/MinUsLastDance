using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using System;

public class PlayerHitFeedback : Feedback
{
    [SerializeField] private Volume _hitVoulme;
    [SerializeField] private float _duration = 1;
    public override void PlayFeedback(float damage)
    {
        StartCoroutine(Hit());
    }

    private IEnumerator Hit()
    {
        _hitVoulme.gameObject.SetActive(true);

        DOTween.To(() => _hitVoulme.weight, x => _hitVoulme.weight = x, 0, _duration);
        
        yield return new WaitForSeconds(_duration);
        _hitVoulme.gameObject.SetActive(false);
        _hitVoulme.weight = 1;
    }

    public override void StopFeedback()
    {
        StopAllCoroutines();
    }
}
