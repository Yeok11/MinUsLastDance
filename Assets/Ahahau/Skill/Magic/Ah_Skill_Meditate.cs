using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Meditate : TK_AttackSkill
{
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        //�÷��̾� ���� 3x3 ���� Ÿ�� ���� * 0.5
        //GetValue(skillLevel, player);
    }
}
