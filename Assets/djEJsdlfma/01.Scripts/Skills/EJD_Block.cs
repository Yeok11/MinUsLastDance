using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Block : TK_BuffSkill
{
    //방어력 N 만큼 얻고 0일시 S만큼 추가 방어력

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
