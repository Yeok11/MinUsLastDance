using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Meal : TK_HealingSkill
{
    private float notMaxHealthEnemy = 0;
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        foreach(var e in Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().enemys)
        {
            if(e.HealthCompo._maxHp == e.HealthCompo._currentHp)
            {
                notMaxHealthEnemy++;
            }
        }
        heal = GetValue(skillLevel, player) * notMaxHealthEnemy;
        base.UseSkill(player, target);
    }
}
