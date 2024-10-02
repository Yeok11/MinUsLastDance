using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Chase : TK_AttackSkill
{
    public override void UseSkill()
    {
        float enemyCount = 0;
        foreach (var e in Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().enemys)
        {
            enemyCount++;
        }
        damage = GetValue(skillLevel) + enemyCount;
    }
}
