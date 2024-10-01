using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TK_PlayerSkillManager tK_PlayerSkillManager = FindObjectOfType<TK_PlayerSkillManager>();

        tK_PlayerSkillManager.UseSkill(ESkillType.Point_Shoot);
    }
}
