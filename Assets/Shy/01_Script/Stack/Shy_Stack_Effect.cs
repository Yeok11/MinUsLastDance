using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STACKACTION_TYPE
{
    ATTACK,
    DEFEND,
    PASSIVE
}

public abstract class Shy_Stack_Effect : Shy_Stack
{
    public int life;
    public STACKACTION_TYPE actionType;

    public abstract Shy_Stack_Effect Init(Transform _target);

    //���� ���� (�⺻ = life 0)
    public virtual bool IsDestroy() 
    {
        if(life-- <= 0)
        {
            DestroyEvent();
            return true;
        }
        return false;
    }

    //�۵��� �� �̺�Ʈ
    public abstract void OnEffect();

    //�ı� �� �� �̺�Ʈ
    public abstract void DestroyEvent();
}
