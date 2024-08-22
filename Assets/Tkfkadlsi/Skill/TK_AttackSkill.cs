using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_AttackSkill : TK_Skill
{
    protected List<Enemy> targets = new List<Enemy>();
    protected float damage;

    public override bool UseSkill()
    {
        return base.UseSkill();
    }

    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
    }
}
