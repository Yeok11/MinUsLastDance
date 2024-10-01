using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_Tanker : Shy_Stack_Effect
{
    private Health _enemyHelath;
    public override void DestroyEvent()
    {
        _enemyHelath._currentBarrier = 0;
    }

    public override Shy_Stack_Effect Init(Transform _target)
    {
        this._enemyHelath = GetComponentInParent<Health>();
        this.life = 1;
        Stack_Tanker s = Instantiate(this, _target);

        return s;
    }

    public override void OnEffect()
    {
        return;
    }
}
