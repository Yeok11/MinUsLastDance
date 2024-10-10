using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public abstract class Skill_Stack : Skill
    {
        internal Shy_Character target;
        public Shy_Stack_Effect effectStackPrefab;
        public Shy_Stack_Cnt countStackPrefab;

        public override void Awake() 
        {
            base.Awake();
        }
    }
}
