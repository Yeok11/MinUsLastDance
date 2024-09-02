using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESkillType
{

}

public abstract class TK_Skill : MonoBehaviour
{
    public ESkillType skillType;
    [SerializeField] [Range(1, 3)] protected int skillLevel = 1;
    [SerializeField] private bool isCanUse = false;
    [SerializeField] private int[] LevelValue = new int[3];

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

    public virtual void UseSkill(Shy_Player player, List<EJY_Enemy> targets)
    {

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