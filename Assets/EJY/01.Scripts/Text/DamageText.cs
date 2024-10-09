using DG.Tweening;
using GGMPool;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour, IPoolable
{
    [field: SerializeField] public PoolTypeSO PoolType { get; private set; }

    public GameObject GameObject => gameObject;

    private TextMeshPro _damageText;
    private Pool _pool;

    private Sequence sq;

    private void Awake()
    {
        _damageText = GetComponent<TextMeshPro>();
    }

    private void OnEnable()
    {
        sq = DOTween.Sequence();
    }

    public void Show(float damage, Transform trm)
    {
        transform.position = trm.position;
        _damageText.text = damage.ToString();

        sq.Append(transform.DOMoveY(transform.position.y + 1, 1.5f))
            .Join(_damageText.DOFade(0, 1.5f))
            .OnComplete(() =>
            {
                _pool.Push(this);
            });
    }

    public void ResetItem()
    {
        _damageText.alpha = 1;
    }

    public void SetUpPool(Pool pool)
    {
        _pool = pool;
    }
}
