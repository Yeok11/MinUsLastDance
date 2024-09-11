using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_ElectricShield : Shy_Stack_Effect
{
    public override void Init()
    {
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
    }

    public override void DestroyEvent()
    {
        Debug.Log("good");
    }
}
