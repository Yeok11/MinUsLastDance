using DG.Tweening;
using GGMPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextFeedback : Feedback
{
    [SerializeField] private PoolTypeSO _poolType;

    private PoolManagerMono _poolManager;

    private void Start()
    {
        _poolManager = Shy_Manager.instance.GetComponentInChildren<PoolManagerMono>();
    }

    public override void PlayFeedback(float damage)
    {
        DamageText damageText = _poolManager._poolManagerSO.Pop(_poolType) as DamageText;
        damageText.Show(damage, transform.parent);
    }

    public override void StopFeedback()
    {
        transform.DOComplete();
    }
}
