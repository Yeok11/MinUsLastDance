using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Barrier : TK_BuffSkill
{
    public override void UseSkill()
    {
        base.UseSkill(player, target);
        player.HealthCompo._addBarrier += 3;
    }
}
