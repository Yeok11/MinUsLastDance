using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_PackHunting : TK_AttackSkill
{
    //��ó 3*3 ũ�� ���� �ִ� ��� Ÿ���� ������ŭ �߼� ������ ���, ������ �� �ϳ����� n�� ���ظ� �ݴϴ�.
    //N = 3 + �߼� * 0.8f / 5 + �߼� * 1.15f / 10 + �߼� * 1.55f ��ȭ�� ���� ���������� ���� 
    public override void UseSkill(Shy_Player player, EJY_Enemy target)
    {
        base.UseSkill(player, target);
        //if(Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Tile>().)
        //�÷��̾� ���� 3*3�ȿ� ��� Ÿ���� ������ŭ �߼� ���� ȹ��
        damage = GetValue(skillLevel, player);
    }
}
