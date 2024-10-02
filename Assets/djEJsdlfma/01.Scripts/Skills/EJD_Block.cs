using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Block : TK_BuffSkill
{
    //���� N ��ŭ ��� 0�Ͻ� S��ŭ �߰� ����

    public override void UseSkill()
    {
        Shy_Player player = FindObjectOfType<Shy_Player>();

        if(player.HealthCompo._currentBarrier > 0)
        {
            player.HealthCompo.GetBarrier(GetValue(skillLevel));
        }
        else
        {
            player.HealthCompo.GetBarrier(GetValue(skillLevel + 3));
        }
    }
}
