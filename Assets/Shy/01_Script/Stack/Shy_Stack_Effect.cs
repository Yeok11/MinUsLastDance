using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STACKACTION_TYPE
{
    ATTACK,
    DEFEND
}

public abstract class Shy_Stack_Effect : Shy_Stack
{
    public int life;
    public STACKACTION_TYPE actionType;

    public virtual void Init() { }

    //작동할 때 이벤트
    public virtual void OnEffect()  { }

    //파괴 될 때 이벤트
    public virtual void OnDestroy() { }
}
