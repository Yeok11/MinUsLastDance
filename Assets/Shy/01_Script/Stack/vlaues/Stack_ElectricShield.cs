using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_ElectricShield : Shy_Stack_Effect
{
    private Health _playerHealth;
    private Health _enemyHealth;
    private float _replactionDamage = 3;

    public override void Init()
    {
        _playerHealth = FindObjectOfType<Shy_Player>().GetComponent<Health>();
        _enemyHealth = GetComponentInParent<Health>();
        actionType = STACKACTION_TYPE.DEFEND;
        life = 2;
    }

    public override bool IsDestroy()
    {
        return base.IsDestroy();
    }

    public override void OnEffect()
    {
        Debug.Log("OnEffect");
        _playerHealth.TakeDamage(_replactionDamage);
    }

    public override void DestroyEvent()
    {
        _enemyHealth._currentBarrier = 0;
    }
}
