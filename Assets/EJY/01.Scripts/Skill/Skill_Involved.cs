using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public abstract class Skill_Involved : Skill
    {
        protected Shy_Manager_Tile smtile;
        protected Shy_Manager_Turn smturn;

        protected virtual void Start()
        {
            smtile = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Tile>();
            smturn = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>();
        }

        public abstract void InvolvedEffectSkill();
    }
}


