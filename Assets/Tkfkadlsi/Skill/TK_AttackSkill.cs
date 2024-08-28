using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_AttackSkill : TK_Skill
{
    protected List<EJY_Enemy> targets = new List<EJY_Enemy>();

    public override bool UseSkill(Shy_Player player)
    {
        return base.UseSkill(player);
    }

    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
    }
}
