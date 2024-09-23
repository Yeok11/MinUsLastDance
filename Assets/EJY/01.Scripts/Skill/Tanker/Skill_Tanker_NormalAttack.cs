using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Tanker_NormalAttack : Skill_Direct
    {
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            float addDamage = 4;
            _playHealth.TakeDamage(_enemyStatSO._damage + addDamage);
        }
    }

}