using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TK_Skill : MonoBehaviour
{
    [Range(1, 3)] protected int skillLevel;
    protected bool isCanUse = false;

    public void SkillUnlock()
    {
        isCanUse = true;
    }

    public bool GetUseable()
    {
        return isCanUse;
    }

    public virtual bool UseSkill()
    {
        if(isCanUse == false)
        {
            return false;
        }
        return true;
    }

    public virtual void SkillLevelUp()
    {
        skillLevel++;
    }
}