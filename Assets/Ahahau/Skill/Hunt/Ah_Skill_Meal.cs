using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Meal : Shy_Skill
{
    private Shy_Player player;

    public override void ActSkill(int _skillLv = 1)
    {
        int cnt = 0;
        foreach (EJY_Enemy e in Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().enemys)
        {
            if (e.HealthCompo._maxHp != e.HealthCompo._currentHp)
                ++cnt;
        }

        if(player == null) player = FindObjectOfType<Shy_Player>();

        player.HealthCompo._currentHp += cnt * calculate.GetValue() * 5;

        if(player.HealthCompo._currentHp > player.HealthCompo._maxHp)
            player.HealthCompo._currentHp = player.HealthCompo._maxHp;
    }
}
