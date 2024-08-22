using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_BuffSkill : TK_Skill
{
    protected SkillStack buffType;
    protected float buffAmount;

    public override bool UseSkill()
    {
        return base.UseSkill();
    }

    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
    }
}
