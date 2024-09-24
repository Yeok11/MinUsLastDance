using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Shild : TK_HealingSkill
{
    //���� (n + ���� �� * s) ��ŭ ���

    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        int enemys = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().enemys.Count;

        base.UseSkill(player, target);

        player.HealthCompo.GetBarrier(GetValue(skillLevel, player) + enemys * GetValue(skillLevel + 3, player));
    }
}
