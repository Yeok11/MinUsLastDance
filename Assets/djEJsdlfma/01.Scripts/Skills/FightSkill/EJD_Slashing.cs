using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Slashing : Shy_Skill
{
    //������ �ϳ����� n ���� s�� �� ����� n*s

    /*public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        for(int i = 0; i < skillLevel; i++)
        {
            damage = GetValue(skillLevel, player);
        }
    }*/

    public override void ActSkill(int _skillLv)
    {
        for (int i = 0; i < _skillLv; i++)
        {
            calculate.GetValue(_skillLv);
        }
    }
}
