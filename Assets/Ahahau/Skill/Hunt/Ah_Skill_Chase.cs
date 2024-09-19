using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Chase : TK_AttackSkill
{
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        float enemyCount = 0;
        foreach (var e in Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().enemys)
        {
            enemyCount++;
        }
        damage = GetValue(skillLevel, player) + enemyCount;
        base.UseSkill(player, target);
    }
}
