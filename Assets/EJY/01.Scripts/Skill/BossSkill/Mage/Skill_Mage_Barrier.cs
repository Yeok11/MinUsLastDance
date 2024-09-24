using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Mage_Barrier : Skill_Stack
    {
        private float weightBarrier;

        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            target.HealthCompo.GetBarrier(weightBarrier);
        }
    }
}
