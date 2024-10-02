using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Meal : Shy_Skill
{
    private float notMaxHealthEnemy = 0;
    [SerializeField]private Shy_Player player;
    public override void ActSkill(int _skillLv = 1)
    {
        foreach (var e in Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().enemys)
        {
            if (player.HealthCompo._maxHp == player.HealthCompo._currentHp)
                break;
            if (e.HealthCompo._maxHp == e.HealthCompo._currentHp)
            {
                
            }
        }
    }    
}
