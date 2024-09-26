using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Bomb_Passive : Skill_Stack
    {
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            target.stacks.Add(effectStackPrefab.Init(target.transform.GetChild(0)));
        }
    }
}