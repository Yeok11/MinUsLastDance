using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextFeedback : Feedback
{
    [SerializeField] private TextMeshProUGUI _damageText;
    private Sequence sq;

    private void OnEnable()
    {
        sq = DOTween.Sequence();
    }

    public override void PlayFeedback(float damage)
    {
            _damageText.gameObject.SetActive(true);
            _damageText.text = damage.ToString();

            sq.Append(transform.DOMoveY(transform.localPosition.y + 1, 1.5f)).
                Join(transform.DOShakePosition(1.5f, 2.5f, 1, 0));
    }

    public override void StopFeedback()
    {
        transform.DOComplete();
    }
}
