using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Banding : TK_HealingSkill
{
    // ü�� n��ŭ ȸ��

    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        //player.HealthCompo._currentHp += asdf.GetValue(skillLevel, player);
    }
}