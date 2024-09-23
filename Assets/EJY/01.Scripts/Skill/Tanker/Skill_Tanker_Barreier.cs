using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Tanker_Barreier : Skill_Barrier
    {
        private float weightBarreier;

        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            weightBarreier = 13 + ((_enemyStatSO._hp * 1.5f) / 10.5f - _enemyStatSO._level * 1.5f);
            target.HealthCompo.GetBarrier(weightBarreier);
        }
    }
}
