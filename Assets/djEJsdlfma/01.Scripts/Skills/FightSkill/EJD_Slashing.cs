using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Slashing : Shy_Skill
{
    //지정적 하나에게 n 피해 s번 총 대미지 n*s

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
