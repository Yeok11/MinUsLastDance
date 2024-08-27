using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TK_Skill : ScriptableObject
{
    [SerializeField] [Range(1, 3)] protected int skillLevel = 1;
    [SerializeField] private bool isCanUse = false;
    [SerializeField] private int[] LevelValue = new int[3];

    public void SkillUnlock()
    {
        isCanUse = true;
    }

    public bool GetUseable()
    {
        return isCanUse;
    }

    public virtual bool UseSkill(Shy_Player player)
    {
        if(GetUseable() == false)
        {
            return false;
        }
        return true;
    }

    public virtual void SkillLevelUp()
    {
        skillLevel++;
    }

    protected int GetLevelValue(int level)
    {
        return LevelValue[level-1];
    }
}