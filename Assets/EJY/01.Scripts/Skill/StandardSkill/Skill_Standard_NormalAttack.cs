using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Standard_NormalAttack : Skill_Direct
    {
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            Debug.Log(_enemyStatSO);
            Debug.Log(_playHealth);
            float addDamage = _enemyStatSO._level * 1.6f;
            _playHealth.TakeDamage(_enemyStatSO._damage + addDamage);
        }
    }
}

