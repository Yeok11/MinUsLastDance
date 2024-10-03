using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Run : Shy_Skill
{
    public override void ActSkill(int _skillLv)
    {
        Shy_Manager_Move actionPoint = new Shy_Manager_Move();
        actionPoint.actionPoint += (int)calculate.GetValue(_skillLv);
    }
}
