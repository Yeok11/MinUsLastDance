using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_PowerSlash : TK_AttackSkill
{
    // 지정 적 하나에게 n 피해 모든 결투타일 리셋

    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        damage = GetValue(skillLevel, player);
    }
}
