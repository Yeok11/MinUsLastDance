using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_MorePowerFul : TK_AttackSkill
{
    // �� �ϳ����� n���� s��ŭ ���� ��
    public override void UseSkill()
    {
        Shy_Player player = FindObjectOfType<Shy_Player>();
        damage = GetValue(skillLevel) + (player.HealthCompo._maxHp - player.HealthCompo._currentHp) * GetValue(skillLevel + 3); 

        //player.HealthCompo.GetBarrier(skillLevel);
    }
}
