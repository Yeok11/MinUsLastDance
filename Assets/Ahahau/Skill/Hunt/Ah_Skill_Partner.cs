using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Partner : TK_AttackSkill
{
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        //헌트 스택 1추가
    }
}
