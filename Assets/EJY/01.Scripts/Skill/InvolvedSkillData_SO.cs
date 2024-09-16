using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class InvolvedSkillData_SO : ScriptableObject
    {
        [SerializeField] private int life;
        [SerializeField] private Skill_Involved skillData;

        public void Init(int _skillCnt, Skill_Involved _skill)
        {
            this.life = _skillCnt;
            this.skillData = _skill;
        }

        public bool Use()
        {
            if(--life == 0)
            {
                skillData.SkillEffectByTurn();
                return true;
            }
            else
                return false;
        }
    }

}

