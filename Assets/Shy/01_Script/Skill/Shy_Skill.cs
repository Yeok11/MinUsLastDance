using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shy_Skill : MonoBehaviour
{
    // 1. �� ��ũ��Ʈ�� ��ӹ޴� ��ũ��Ʈ ����
    // 2. �ڵ� �ۼ�
    // 3. Prefab/Skill�� �ִ� TileBase�� ���� �� �̸��� TileBase_{��ų �̸�}���� ����
    // 4. Tile_Skill_{��ų �̸�}���� TileSkill SO �����ؼ� Effect�� 3���� ���� ������Ʈ ����ֱ�

    public TK_SkillConst calculate;

    public void Attack(int _damage, Health _targetHealth)
    {
        _targetHealth.TakeDamage(_damage);
        Debug.Log("value : " + _damage);
    }

    public abstract void ActSkill(int _skillLv = 1);
}
