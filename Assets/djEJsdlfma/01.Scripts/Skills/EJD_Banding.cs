using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Banding : TK_HealingSkill
{
    // 체력 n만큼 회복

    public override void UseSkill()
    {
        FindObjectOfType<Shy_Player>().HealthCompo._currentHp += GetValue(skillLevel);
    }
}