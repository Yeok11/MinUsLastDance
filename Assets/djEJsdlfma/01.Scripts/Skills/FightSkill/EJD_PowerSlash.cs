using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_PowerSlash : Shy_Skill
{
    // ���� �� �ϳ����� n ���� ��� ����Ÿ�� ����

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
