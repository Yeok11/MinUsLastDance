using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointShootSkill : TK_AttackSkill
{
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        //여기서 데미지 계산 후 Attack
        base.UseSkill(player, target);
        damage = /*계산한 최대체력 아닌 적의 수 곱하기*/ GetValue(skillLevel, player);
        Attack(target);
    }
}
