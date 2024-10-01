using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_MorePowerFul : Shy_Skill
{
    // 적 하나에게 n피해 s만큼 방어력 득
    /*public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);

        damage = GetValue(skillLevel, player) + (player.HealthCompo._maxHp - player.HealthCompo._currentHp) * GetValue(skillLevel + 3, player); 

        //player.HealthCompo.GetBarrier(skillLevel);
    }*/

    private Shy_Player player;

    public override void ActSkill(int _skillLv = 1)
    {
        float damage;

        damage = calculate.GetValue(_skillLv) + (player.HealthCompo._maxHp - player.HealthCompo._currentHp) * calculate.GetValue(_skillLv + 3);
    }
}
