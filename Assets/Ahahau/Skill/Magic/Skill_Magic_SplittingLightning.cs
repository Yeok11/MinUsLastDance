using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Magic_SplittingLightning : TK_AttackSkill
{
    //모든적에게 피해
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        //방어력이 있는 적의 수만큼 마나 획득
    }
}
