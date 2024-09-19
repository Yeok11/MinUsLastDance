using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Electro_NormalAttack : Skill_Direct
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            float damage = 22;
            _playHealth.TakeDamage(damage);
        }
    }
}

