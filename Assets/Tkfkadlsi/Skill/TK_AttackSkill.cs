using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_AttackSkill : TK_Skill
{
    protected float damage;

    public override bool CanUseSkill(Shy_Player player)
    {
        return base.CanUseSkill(player);
    }

    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
    }

    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
    }

    protected void Attack(EJY_Enemy target)
    {
        target.HealthCompo.TakeDamage(damage);
    }
}