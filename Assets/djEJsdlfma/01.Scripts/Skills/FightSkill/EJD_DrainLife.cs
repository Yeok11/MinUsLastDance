using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_DrainLife : Shy_Skill
{
    // ���� �� �ϳ����� n����, óġ�� s��ŭ ȸ��
    /*public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        damage = GetValue(skillLevel, player);

        //target�� �׾��ٸ� s ü��ȸ��

  *//*      if (target.HealthCompo._currentHp <= 0)
        {
            player.HealthCompo._currentHp += 123;
        }*//*
    }*/

    public override void ActSkill(int _skillLv)
    {
        calculate.GetValue(_skillLv);
    }
}
