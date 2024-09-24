using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Mage_NormalAttack : Skill_Direct
    {
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            //float add =
            _playHealth.TakeDamage(0);
        }
    }
}
