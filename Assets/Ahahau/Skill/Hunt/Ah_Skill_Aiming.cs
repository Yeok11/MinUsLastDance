using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Aiming : TK_AttackSkill
{
    //�߼� ������ n��ŭ ����ϴ�, �̹� �������� ���� ������ �ϳ� �߰��մϴ�.
    //N = 2 + (�̹� �Ͽ� ����� ��� Ÿ���� �� * 0.5) ��ȭ �Ұ� 
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);

    }
}