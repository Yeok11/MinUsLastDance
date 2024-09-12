using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Elector_NormalAttack : Skill_Direct
    {
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void SkillEffect()
        {
            float damage = 22;
            _playHealth.TakeDamage(damage);
        }
    }
}

