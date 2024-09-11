using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointShootSkill : TK_AttackSkill
{
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        //여기서 데미지 계산 후 Attack
        base.UseSkill(player, target);
        damage = GetValue(skillLevel, player);
        Debug.Log(damage);
        Attack(target);
    }
}
