using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_PowerSlash : TK_AttackSkill
{
    // ���� �� �ϳ����� n ���� ��� ����Ÿ�� ����

    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        damage = GetValue(skillLevel, player);
    }
}
