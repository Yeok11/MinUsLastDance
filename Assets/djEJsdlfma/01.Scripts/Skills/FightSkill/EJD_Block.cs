using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Block : Shy_Skill
{
    //방어력 N 만큼 얻고 0일시 S만큼 추가 방어력

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
