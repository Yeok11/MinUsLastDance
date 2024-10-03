using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shy_Skill_Apple : Shy_Skill
{
    public override void ActSkill(int _skillLv)
    {
        Debug.Log("����� ����~");
        Debug.Log(calculate.GetValue(_skillLv).ToString());
    }
}
