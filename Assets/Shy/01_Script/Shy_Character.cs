using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shy_Character : MonoBehaviour
{
    public Health HealthCompo { get; protected set; }
    public List<Shy_Stack> stacks;

    public virtual void AttackEvent()
    {
        foreach (Shy_Stack stack in stacks)
        {
            if (stack.TryGetComponent(out Shy_Stack_Effect stEffect))
            {
                if (stEffect.actionType == STACKACTION_TYPE.ATTACK)
                    stEffect.OnEffect();
            }
        }
    }

    public virtual void DefenceEvent()
    {
        foreach (Shy_Stack stack in stacks)
        {
            if (stack.TryGetComponent(out Shy_Stack_Effect stEffect))
            {
                if(stEffect.actionType == STACKACTION_TYPE.DEFEND)
                    stEffect.OnEffect();
            }
        }
    }
}
