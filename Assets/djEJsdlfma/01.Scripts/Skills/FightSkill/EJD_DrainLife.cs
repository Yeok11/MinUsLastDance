using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_DrainLife : Shy_Skill
{
    // 지정 적 하나에게 n피해, 처치시 s만큼 회복
    /*public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        damage = GetValue(skillLevel, player);

        //target이 죽었다면 s 체력회복

  *//*      if (target.HealthCompo._currentHp <= 0)
        {
            player.HealthCompo._currentHp += 123;
        }*//*
    }*/

    public override void ActSkill(int _skillLv)
    {
        calculate.GetValue(_skillLv);
    }
}
