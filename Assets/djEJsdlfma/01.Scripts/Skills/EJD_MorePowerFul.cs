using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_MorePowerFul : TK_AttackSkill
{
    // 적 하나에게 n피해 s만큼 방어력 득
    public override void UseSkill()
    {
        Shy_Player player = FindObjectOfType<Shy_Player>();
        damage = GetValue(skillLevel) + (player.HealthCompo._maxHp - player.HealthCompo._currentHp) * GetValue(skillLevel + 3); 

        //player.HealthCompo.GetBarrier(skillLevel);
    }
}
