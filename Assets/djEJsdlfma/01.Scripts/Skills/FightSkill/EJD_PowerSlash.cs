using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_PowerSlash : Shy_Skill
{
    // 지정 적 하나에게 n 피해 모든 결투타일 리셋

    private Shy_Tile tileReset;

    /*public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        damage = GetValue(skillLevel, player);

        tileReset.SettingTile();
    }*/

    public override void ActSkill(int _skillLv)
    {
        calculate.GetValue(_skillLv);
        tileReset.SettingTile();
    }
}
