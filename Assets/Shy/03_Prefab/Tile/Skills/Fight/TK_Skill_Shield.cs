using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_Skill_Shield : Shy_Skill
{
    Shy_Manager_Turn turnManager;
    Shy_Player player;

    public override void ActSkill(int _skillLv = 1)
    {
        if(player == null)
        {
            player = FindObjectOfType<Shy_Player>();
        }
        if(turnManager == null)
        {
            turnManager = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>();
        }

        float m = 0f;

        switch(_skillLv)
        {
            case 1:
                m = 0.8f;
                break;
            case 2:
                m = 1.1f;
                break;
            case 3:
                m = 1.5f;
                break;
        }

        int value = (int)(calculate.GetValue(_skillLv) + turnManager.enemys.Count * m);

        player.HealthCompo.GetBarrier(value);
    }
}
