using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Partner : Shy_Skill
{
    public override void ActSkill(int _skillLv = 1)
    {
        FindObjectOfType<Shy_Player>().SetStack(COUNT_STACK_TYPE.HUNT, 1);
        int damage = Mathf.RoundToInt(calculate.GetValue(_skillLv));
        Attack(damage, Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Enemy>().ChangeRandomTarget().HealthCompo);
    }
}
