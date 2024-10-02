using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Brawling : TK_AttackSkill
{
    // 무작위 적 둘에게 n 피해 2-4 번 대미지
    public override void UseSkill()
    {
        int howMuchAttack = Random.Range(2, 5);

        for(int i = 0; i < howMuchAttack; i++)
        {
            damage = GetValue(skillLevel);
        }
    }
}
