using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Block : Shy_Skill
{
    //���� N ��ŭ ��� 0�Ͻ� S��ŭ �߰� ����

    private Shy_Player player;
    public override void ActSkill(int _skillLv)
    {
        if(player.HealthCompo._currentBarrier > 0)
        {
            player.HealthCompo.GetBarrier(calculate.GetValue(_skillLv));
        }
        else
        {
            player.HealthCompo.GetBarrier(calculate.GetValue(_skillLv + 3));
        }
    }
}
