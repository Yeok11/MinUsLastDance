using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Burst : Shy_Skill
{
    public override void ActSkill(int _skillLv = 1)
    {
        int damage = Mathf.RoundToInt(calculate.GetValue(_skillLv));
        if(PlayerTargetting._target.HealthCompo._currentBarrier + PlayerTargetting._target.HealthCompo._currentHp <= damage)
        {
            FindObjectOfType<Shy_Player>().SetStack(COUNT_STACK_TYPE.HUNT, 1);
        }
        Attack(damage, PlayerTargetting._target.HealthCompo);
    }
}
