using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_PackHunting : Shy_Skill
{
    public override void ActSkill(int _skillLv = 1)
    {
        Shy_Player player = FindObjectOfType<Shy_Player>();
        EJY_Player player2 = player.GetComponent<EJY_Player>();

        int pos = player2._currentTileIdx, cnt = 0;

        for (int h = (pos / 7 == 0 ? 0 : -1); h < (pos / 7 == 6 ? 1 : 2); h++)
        {
            for (int w = (pos % 7 == 0 ? 0 : -1); w < (pos % 7 == 6 ? 1 : 2); w++)
            {
                int value = pos + h * 7 + w;

                if (player2._tileManager.tileObjs[value].skillData == null) continue;
                if(player2._tileManager.tileObjs[value].skillData.thema == SKILLTHEMA.HUNTING) ++cnt;
            }
        }

        player.SetStack(COUNT_STACK_TYPE.HUNT, cnt);
        int damage = Mathf.RoundToInt(calculate.GetValue(_skillLv));
        Attack(damage, PlayerTargetting._target.HealthCompo);
    }
}

