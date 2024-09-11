using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_ElectricShield : Shy_Stack_Effect
{
    public override void Init()
    {
        actionType = STACKACTION_TYPE.DEFEND;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnEffect()
    {
        base.OnEffect();
    }
}
