using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Banding : Shy_Skill
{
    // ü�� n��ŭ ȸ��

    /*public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        player.HealthCompo._currentHp += GetValue(skillLevel, player);
    }*/
    private Shy_Player player;

    public override void ActSkill(int _skillLv)
    {
        player.HealthCompo._currentHp += calculate.GetValue(_skillLv);
    }
}