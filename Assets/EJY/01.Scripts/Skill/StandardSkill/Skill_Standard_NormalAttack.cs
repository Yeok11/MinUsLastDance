using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Standard_NormalAttack : Skill_Direct
    {
        private void Start()
        {
            _damage = _enemyStatSO._level * 2.4f;
        }
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void SkillEffect()
        {
            float addDamage = _enemyStatSO._level * 1.6f;
            _playHealth.TakeDamage(_damage + addDamage);
        }
    }
}

