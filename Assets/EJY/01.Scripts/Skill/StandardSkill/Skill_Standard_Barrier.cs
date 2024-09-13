using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Standard_Barrier : Skill_Stack
    {
        private float weightBarrier;
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void SkillEffect()
        {
            weightBarrier = (_enemyStatSO._level * 2.3f) + _enemyStatSO._damage;
            target.HealthCompo.GetBarrier(weightBarrier);
        }
    }
}

