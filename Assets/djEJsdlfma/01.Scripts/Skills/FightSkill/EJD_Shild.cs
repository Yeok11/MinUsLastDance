using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Shild : Shy_Skill
{
    //방어력 (n + 적의 수 * s) 만큼 얻기

    /* public override void UseSkill(Shy_Player player, EJY_Enemy target)
     {
         int enemys = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().enemys.Count;

         base.UseSkill(player, target);

         player.HealthCompo.GetBarrier(GetValue(skillLevel, player) + enemys * GetValue(skillLevel + 3, player));
     }*/

    private Shy_Player player;

    public override void ActSkill(int _skillLv = 1)
    {
        int enemys = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().enemys.Count;
        player.HealthCompo.GetBarrier(calculate.GetValue(_skillLv) + enemys * calculate.GetValue(_skillLv + 3));
    }
}
