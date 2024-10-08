using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace EJY
{
    public class Skill_Mage_NormalAttack : Skill_Direct
    {

        [SerializeField] private Transform _stackPosTrm;
        private Shy_Stack_Cnt _countStack;

        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            if (_countStack == null)
                _countStack = _stackPosTrm.GetComponentInChildren<Shy_Stack_Cnt>();

            float add = _countStack.count * 2.4f;
            _playHealth.TakeDamage(add);
        }
    }
}
