using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Meditate : TK_AttackSkill
{
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        //플레이어 기준 3x3 마법 타일 개수 * 0.5
        //GetValue(skillLevel, player);
    }
}
