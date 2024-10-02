using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESkillType
{
    Point_Shoot,
}

public abstract class TK_Skill : MonoBehaviour
{
    public ESkillType skillType;
    [SerializeField] private TK_SkillConst skillConst;
    [SerializeField] [Range(1, 3)] protected int skillLevel = 1;
    [SerializeField] private bool isCanUse = false;

    public void SkillUnlock()
    {
        isCanUse = true;
    }

    public virtual bool CanUseSkill(Shy_Player player)
    {
        if(isCanUse == false)
        {
            return false;
        }
        return true;
    }

    public virtual void UseSkill()
    {

    }

    public virtual void SkillLevelUp()
    {
        skillLevel++;
    }

    protected float GetValue(int level)
    {
        return skillConst.GetValue(level);
    }
}