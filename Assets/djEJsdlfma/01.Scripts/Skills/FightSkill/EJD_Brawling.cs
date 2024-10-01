using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Brawling : Shy_Skill
{
    // 무작위 적 둘에게 n 피해 2-4 번 대미지
    /*public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        int howMuchAttack = Random.Range(2, 5);

        for(int i = 0; i < howMuchAttack; i++)
        {
            damage = GetValue(skillLevel, player);
        }
    }*/

    private Shy_Player player;

    public override void ActSkill(int _skillLv = 1)
    {
        int howMuchAttack = Random.Range(2, 5);

        for (int i = 0; i < howMuchAttack; i++)
        {
            calculate.GetValue(_skillLv);
        }
    }
}
