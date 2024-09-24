using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Mage_Barrier : Skill_Stack
    {
        [SerializeField] private Transform _stackPosTrm; 
        private float weightBarrier;
        private Shy_Stack_Cnt _countStack;

        public override void Awake()
        {
            target = GetComponentInParent<Shy_Character>();
        }

        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            if(_countStack == null)
                _countStack = _stackPosTrm.GetComponentInChildren<Shy_Stack_Cnt>();

            weightBarrier = _countStack.count * 1.5f;
            target.HealthCompo.GetBarrier(weightBarrier);
        }
    }
}
