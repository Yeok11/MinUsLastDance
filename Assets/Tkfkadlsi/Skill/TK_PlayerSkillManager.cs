using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_PlayerSkillManager : MonoBehaviour
{
    private Shy_Player player;
    private Dictionary<ESkillType, TK_Skill> skillDic = new Dictionary<ESkillType, TK_Skill>();

    private void Awake()
    {
        player = GetComponent<Shy_Player>();
        TK_Skill[] skillarray = GetComponents<TK_Skill>();

        foreach (TK_Skill skill in skillarray)
        {
            skillDic.Add(skill.skillType, skill);
        }
    }

    public void UseSkill(ESkillType skill)
    {
        if(skillDic[skill].CanUseSkill(player))
        {
            skillDic[skill].UseSkill(player, new List<EJY_Enemy>());
        }
    }
}
