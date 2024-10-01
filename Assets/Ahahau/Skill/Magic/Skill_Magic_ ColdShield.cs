using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Magic_ColdShield : TK_BuffSkill
{
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        //다음 턴까지 데미지를 입지않음
    }
}
