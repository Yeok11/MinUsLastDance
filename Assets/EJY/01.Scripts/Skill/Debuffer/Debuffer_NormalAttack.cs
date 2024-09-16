using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Debuffer_NormalAttack : Skill_Direct
    {
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            _playHealth.TakeDamage(7 + (_enemyStatSO._damage / 2));
        }
    }
}
