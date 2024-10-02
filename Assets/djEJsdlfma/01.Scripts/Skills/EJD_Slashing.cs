using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Slashing : TK_AttackSkill
{
    //지정적 하나에게 n 피해 s번 총 대미지 n*s

    public override void UseSkill()
    {
        for(int i = 0; i < skillLevel; i++)
        {
            damage = GetValue(skillLevel);
        }
    }
}
