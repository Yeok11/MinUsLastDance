using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_FruitBaskit : Shy_Skill
{
    public override void ActSkill(int _skillLv = 1)
    {
        Shy_Player player = new Shy_Player();
        Shy_Manager_Move actionPoint = new Shy_Manager_Move();

        player.HealthCompo._currentHp += calculate.GetValue(_skillLv);
        actionPoint.actionPoint += 3;
    }
}
