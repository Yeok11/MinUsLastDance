using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_BuffSkill : TK_Skill
{
    [SerializeField] protected TK_SkillStack buffType;

    public override bool UseSkill(Shy_Player player)
    {
        return base.UseSkill(player);
    }

    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
    }
}
