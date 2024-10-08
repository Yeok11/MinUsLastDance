using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_Skill_Melee : Shy_Skill
{
    public override void ActSkill(int _skillLv = 1)
    {
        Shy_Manager_Enemy enemyManager = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Enemy>();
        int damage = (int)calculate.GetValue(_skillLv);

        for(int i = 0; i < 2; i++)
        {
            EJY_Enemy target = enemyManager.ChangeRandomTarget();
            for(int j = 0; j < Random.Range(2, 5); j++)
            {
                Attack(damage, target.HealthCompo);
            }
        }
    }
}
