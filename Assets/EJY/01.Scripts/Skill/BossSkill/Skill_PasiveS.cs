using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_PasiveS : Skill_Stack
    {
        protected float weightBarrier;
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
            target.stacks.Add(effectStackPrefab.Init(target.transform.GetChild(0)));
            target.stacks.Add(effectStackPrefab);

            //방어력 계산
            weightBarrier = 30 + (target.HealthCompo._maxHp - target.HealthCompo._currentHp) * 0.15f; 

            target.HealthCompo.GetBarrier(weightBarrier);
        }
    }
}