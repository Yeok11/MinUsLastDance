using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Banding : TK_HealingSkill
{
    // ü�� n��ŭ ȸ��

    public override void UseSkill()
    {
        FindObjectOfType<Shy_Player>().HealthCompo._currentHp += GetValue(skillLevel);
    }
}