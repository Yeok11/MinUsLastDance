using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Debuffer_Passive : Skill_Stack
    {
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void SkillEffect()
        {
            stackPrefab.Init();
        }
    }

}
