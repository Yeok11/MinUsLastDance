using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_BarrierElectro : Skill_Stack
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
<<<<<<<< HEAD:Assets/EJY/01.Scripts/Skill/BossSkill/Skill_PasiveS.cs
            target.stacks.Add(stackPrefab.Init(target.transform.GetChild(0)));
========
            target.stacks.Add(stackPrefab);

            //���� ���
            weightBarrier = 30 + (target.HealthCompo._maxHp - target.HealthCompo._currentHp) * 0.15f; 

            target.HealthCompo.GetBarrier(weightBarrier);
>>>>>>>> origin/EJY:Assets/EJY/01.Scripts/Skill/BossSkill/ElectroFrog/Skill_BarrierElectro.cs
        }
    }
}
