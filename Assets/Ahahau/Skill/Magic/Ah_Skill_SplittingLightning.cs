using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_SplittingLightning : TK_AttackSkill
{
    //��������� ����
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        //������ �ִ� ���� ����ŭ ���� ȹ��
        //if(target._barrier < 0)
        //{
        //    damage++;
        //}
    }
}
