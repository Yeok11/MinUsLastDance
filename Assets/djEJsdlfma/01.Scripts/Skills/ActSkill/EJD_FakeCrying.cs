using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_FakeCrying : Shy_Skill
{
    private EJY_Enemy _enemy;
    private Shy_Manager_Turn resetDamage;

    public override void ActSkill(int _skillLv)
    {
        _enemy.stat._damage -= 2;
        //턴 끝나면 적 데미지 되돌리기
    }
}
