using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Brawling : TK_AttackSkill
{
    // ������ �� �ѿ��� n ���� 2-4 �� �����
    public override void UseSkill()
    {
        int howMuchAttack = Random.Range(2, 5);

        for(int i = 0; i < howMuchAttack; i++)
        {
            damage = GetValue(skillLevel);
        }
    }
}
