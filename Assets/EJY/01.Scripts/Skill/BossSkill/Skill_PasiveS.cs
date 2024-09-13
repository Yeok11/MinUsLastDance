using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_PasiveS : Skill_Stack
    {
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
            target.stacks.Add(stackPrefab.Init(target.transform.GetChild(0)));
        }
    }
}