using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shy_Skill_Apple : Shy_Skill
{
    public override void ActSkill(int _skillLv)
    {
        Debug.Log("사과가 좋아~");
        Debug.Log(calculate.GetValue(_skillLv).ToString());
    }
}
