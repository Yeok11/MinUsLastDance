using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_AttackSkill : TK_Skill
{
    [SerializeField] protected float damage;
    protected List<EJY_Enemy> targets = new List<EJY_Enemy>();

    public override bool CanUseSkill(Shy_Player player)
    {
        return base.CanUseSkill(player);
    }

    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
    }

    public override void UseSkill(Shy_Player player, List<EJY_Enemy> targets)
    {
        base.UseSkill(player, targets);
    }

    protected void Attack()
    {
        targets.ForEach(e =>
        {
            e.HealthCompo.TakeDamage(damage);
        });
    }
}
