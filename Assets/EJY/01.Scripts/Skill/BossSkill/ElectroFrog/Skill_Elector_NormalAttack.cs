using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Elector_NormalAttack : Skill_Direct
    {
        private void Start()
        {
            _damage = 22;
        }
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void SkillEffect()
        {
            _playHealth.TakeDamage(_damage);
        }
    }
}

