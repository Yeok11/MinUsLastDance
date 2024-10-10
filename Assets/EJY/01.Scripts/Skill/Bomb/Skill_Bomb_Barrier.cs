using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Bomb_Barrier : Skill_Barrier
    {
        private float weightBarrier;
        private Shy_Stack_Effect _bomb;

        public override void Awake()
        {
            _bomb = GetComponent<Shy_Stack_Effect>();
        }
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            if(_bomb != null)
            _bomb.life--;
            
            weightBarrier = _enemyStatSO._hp / 2;
            target.HealthCompo.GetBarrier(weightBarrier);

        }
    }
}

