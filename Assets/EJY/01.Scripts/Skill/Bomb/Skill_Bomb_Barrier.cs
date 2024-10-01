using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Bomb_Barrier : Skill_Barrier
    {
        private float weightBarrier;
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            weightBarrier = _enemyStatSO._hp / 2;
            target.HealthCompo.GetBarrier(weightBarrier);
        }
    }
}

