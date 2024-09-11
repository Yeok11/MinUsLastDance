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

    //�۵��� �� �̺�Ʈ
    public virtual void OnEffect()  { }

    //�ı� �� �� �̺�Ʈ
    public virtual void OnDestroy() { }
}
