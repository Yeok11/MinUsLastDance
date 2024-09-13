using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_ElectricShield : Shy_Stack_Effect
{
    public override Shy_Stack_Effect Init(Transform _target)
    {
        Shy_Stack_Effect s =  Instantiate(this, _target);
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
        Debug.Log("OnEffect");
    }

    public override void DestroyEvent()
    {
        Debug.Log("good");
    }

   
}
