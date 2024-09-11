using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public abstract class Skill_Involved : Skill
    {
        protected Shy_Manager_Tile smt;
        protected Shy_Manager_Turn smturn;

        protected virtual void Start()
        {
            smt = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Tile>();
            smturn = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>();
        }

        public abstract void SkillActivated();
    }
}


