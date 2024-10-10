using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Mage_Passive : Skill_Stack
    {
        private Shy_Stack_Cnt stackCnt;

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
            if (stackCnt != null)
            {
                stackCnt.count += 2;
            }
            else
            {
                stackCnt = Instantiate(countStackPrefab);
                stackCnt.transform.parent = target.transform.GetChild(0);
                stackCnt.count = 2;
                target.stacks.Add(stackCnt);
            }
        }
    }
}
