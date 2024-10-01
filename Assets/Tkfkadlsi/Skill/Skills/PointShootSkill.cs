using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointShootSkill : TK_AttackSkill
{
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        //���⼭ ������ ��� �� Attack
        base.UseSkill(player, target);
        damage = /*����� �ִ�ü�� �ƴ� ���� �� ���ϱ�*/ GetValue(skillLevel, player);
        Attack(target);
    }
}
