using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_Bomb_Passive : Skill_Stack
    {
        [SerializeField] private Transform _stacks;
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
            target.stacks.Add(effectStackPrefab.Init(_stacks));
            target.GetComponent<EJY_Enemy>()._enemySkill.Remove(this);
        }
    }
}