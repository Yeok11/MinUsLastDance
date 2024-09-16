using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Meal : TK_HealingSkill
{
    private int notMaxEnemy = 0;
    [SerializeField] private List<EJY_Enemy> enemy = new List<EJY_Enemy>();
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        foreach(var e in enemy)
        {
            if(e.HealthCompo._maxHp == e.HealthCompo._currentHp)
            {
                notMaxEnemy++;
            }
        }
        base.UseSkill(player, target);
    }
}
