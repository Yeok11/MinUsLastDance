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
            if (player.HealthCompo._maxHp == player.HealthCompo._currentHp)
                break;
            if(e.HealthCompo._maxHp == e.HealthCompo._currentHp )
            {
                player.HealthCompo._currentHp++;
            }
        }
        
        base.UseSkill(player, target);
    }
}
