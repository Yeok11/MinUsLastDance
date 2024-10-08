using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Shooting : Shy_Skill
{
    public override void ActSkill(int _skillLv = 1)
    {
        Attack(Mathf.RoundToInt(calculate.GetValue(_skillLv)), 
            Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Enemy>().ChangeRandomTarget().HealthCompo);
    }
}
