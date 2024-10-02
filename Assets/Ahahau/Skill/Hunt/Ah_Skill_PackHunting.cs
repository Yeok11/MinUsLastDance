using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_PackHunting : TK_AttackSkill
{
    //근처 3*3 크기 내에 있는 사냥 타일의 개수만큼 야성 스택을 얻고, 지정한 적 하나에게 n의 피해를 줍니다.
    //N = 3 + 야성 * 0.8f / 5 + 야성 * 1.15f / 10 + 야성 * 1.55f 강화에 따라 순차적으로 증가 
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        //if(Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Tile>().)
        //플레이어 기준 3*3안에 사냥 타일의 개수만큼 야성 스택 획득
        damage = GetValue(skillLevel, player);
    }
}
