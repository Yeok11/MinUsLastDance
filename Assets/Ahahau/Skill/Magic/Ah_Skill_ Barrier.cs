using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Barrier : TK_BuffSkill
{
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        player.HealthCompo._addBarrier += 3;
    }
}
