using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Block : TK_BuffSkill
{
    //���� N ��ŭ ��� 0�Ͻ� S��ŭ �߰� ����

    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        if(player.HealthCompo._currentBarrier > 0)
        {
            player.HealthCompo.GetBarrier(GetValue(skillLevel, player));
        }
        else
        {
            player.HealthCompo.GetBarrier(GetValue(skillLevel + 3, player));
        }
    }
}
