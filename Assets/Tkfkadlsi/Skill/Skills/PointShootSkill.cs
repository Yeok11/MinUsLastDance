using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointShootSkill : TK_AttackSkill
{
    public override void UseSkill()
    {
        //¿©±â¼­ µ¥¹ÌÁö °è»ê ÈÄ Attack


        damage = GetValue(skillLevel);
        Debug.Log(damage);


        Targetting._target.HealthCompo.TakeDamage(damage);
    }
}