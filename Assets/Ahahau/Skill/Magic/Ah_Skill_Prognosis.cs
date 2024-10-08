using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Prognosis : Shy_Skill
{
    [SerializeField] private Shy_Player player; 
    public override void ActSkill(int _skillLv = 1)
    {
        //두명의 적에게 피해 입힘
        calculate.GetValue(_skillLv);
    }
}
