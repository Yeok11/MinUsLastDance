using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_Skill_Bandage : Shy_Skill
{
    public override void ActSkill(int _skillLv = 1)
    {
        Shy_Player player = FindObjectOfType<Shy_Player>();

        int value = (int)calculate.GetValue(_skillLv);

        player.HealthCompo._currentHp += value;

        if(player.HealthCompo._currentHp > player.HealthCompo._maxHp)
            player.HealthCompo._currentHp = player.HealthCompo._maxHp;
    }
}
