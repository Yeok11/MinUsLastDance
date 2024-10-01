using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_TestPassive : Shy_Stack_Effect
{
    public override void DestroyEvent()
    {
    }

    public override Shy_Stack_Effect Init(Transform _target)
    {
        Shy_Stack_Effect s =  Instantiate(this, _target);
        s.actionType = STACKACTION_TYPE.PASSIVE;

        return s;
    }

    public override bool IsDestroy()
    {
        return base.IsDestroy();
    }

    public override void OnEffect()
    {
    }
}
