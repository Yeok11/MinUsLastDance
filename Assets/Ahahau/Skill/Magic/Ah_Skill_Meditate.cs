using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Meditate : Shy_Skill
{
    [SerializeField] private Shy_Player player;
    public override void ActSkill(int _skillLv = 1)
    {
        //�÷��̾� ���� 3x3 ���� Ÿ�� ����
        calculate.GetValue(_skillLv);
    }
}
