using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Shild : TK_HealingSkill
{
    //���� (n + ���� �� * s) ��ŭ ���

    public override void UseSkill()
    {
        int enemys = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().enemys.Count;

        FindObjectOfType<Shy_Player>().HealthCompo.GetBarrier(GetValue(skillLevel) + enemys * GetValue(skillLevel + 3));
    }
}
