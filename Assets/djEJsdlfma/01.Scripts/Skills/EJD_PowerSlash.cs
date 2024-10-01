using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_PowerSlash : TK_AttackSkill
{
    //야성 스택을 n만큼 얻습니다, 이번 전투동안 덱에 조준을 하나 추가합니다.
    //N = 2 + (이번 턴에 사용한 사냥 타일의 수 * 0.5) 강화 불가 
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        foreach (var e in Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Tile>().tileObjs)
        {
            //타입 if문으로 계산해서 더해줌
        }
    }
}
