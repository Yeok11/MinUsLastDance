using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Slashing : TK_AttackSkill
{
    //������ �ϳ����� n ���� s�� �� ����� n*s

    public override void UseSkill()
    {
        for(int i = 0; i < skillLevel; i++)
        {
            damage = GetValue(skillLevel);
        }
    }
}
