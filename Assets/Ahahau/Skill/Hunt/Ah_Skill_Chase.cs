using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Chase : Shy_Skill
{
    [SerializeField]private Shy_Player player;
    public override void ActSkill(int _skillLv = 1)
    {
        float enemyCount = 0;
        foreach (var e in Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().enemys)
        {
            enemyCount++;
        }
        calculate.GetValue(_skillLv)/* + enemyCount*/;
    }
}
