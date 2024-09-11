using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skilldata_SO : ScriptableObject
    {
        [SerializeField] private int life;
        [SerializeField] private Skill skillData;

        public void Init(int _skillCnt, Skill _skill)
        {
            this.life = _skillCnt;
            this.skillData = _skill;
        }

        public bool Use()
        {
            if(--life == 0)
            {
                skillData.SkillEffect();
                return true;
            }
            else
                return false;
        }
    }

}

