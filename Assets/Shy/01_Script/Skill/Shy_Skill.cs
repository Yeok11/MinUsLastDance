using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shy_Skill : MonoBehaviour
{
    // 1. 이 스크립트를 상속받는 스크립트 생성
    // 2. 코드 작성
    // 3. Prefab/Skill에 있는 TileBase를 복사 후 이름을 TileBase_{스킬 이름}으로 변경
    // 4. Tile_Skill_{스킬 이름}으로 TileSkill SO 생성해서 Effect에 3에서 만든 오브젝트 집어넣기

    public TK_SkillConst calculate;

    public void Attack(int _damage, Health _targetHealth)
    {
        _targetHealth.TakeDamage(_damage);
        Debug.Log("value : " + _damage);
    }

    public abstract void ActSkill(int _skillLv = 1);
}
