using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_ElectricShield : Shy_Stack_Effect
{
    internal Health _playerHealth;
    internal Health _enemyHealth;
    internal float _replactionDamage = 3;


    public override Shy_Stack_Effect Init(Transform _target)
    {
        Stack_ElectricShield s =  Instantiate(this, _target);
        s._playerHealth = FindObjectOfType<Shy_Player>().GetComponent<Health>();
        s._enemyHealth = GetComponentInParent<Health>();
        s.actionType = STACKACTION_TYPE.DEFEND;
        s.life = 2;

        return s;
    }

    public override bool IsDestroy()
    {
        return base.IsDestroy();
    }

    public override void OnEffect()
    {
        _playerHealth.TakeDamage(_replactionDamage);
    }

    public override void DestroyEvent()
    {
        _enemyHealth._currentBarrier = 0;
    }

   
}
