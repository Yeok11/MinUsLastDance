using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_ColdShield : Shy_Skill
{
    [SerializeField]private Shy_Player player;
    public override void ActSkill(int _skillLv = 1)
    {
        calculate.GetValue(_skillLv);
    }
}
