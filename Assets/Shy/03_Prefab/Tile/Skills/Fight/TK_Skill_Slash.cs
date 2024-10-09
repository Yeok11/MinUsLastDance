using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_Skill_Slash : Shy_Skill
{
    public override void ActSkill(int _skillLv = 1)
    {
        int damage = (int)calculate.GetValue(_skillLv);

        for(int i = 0; i < _skillLv; i++)
        {
            Attack(damage, PlayerTargetting._target.HealthCompo);
        }
    }
}
