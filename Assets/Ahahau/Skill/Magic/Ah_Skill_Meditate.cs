using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Meditate : Shy_Skill
{
    [SerializeField] private Shy_Player player;
    public override void ActSkill(int _skillLv = 1)
    {
        //플레이어 기준 3x3 마법 타일 개수
        calculate.GetValue(_skillLv);
    }
}
