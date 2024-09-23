using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class DebufferEnemy : EJY_Enemy
    {
        protected override void EnemyAction()
        {
        }

        private void OnEnable()
        {
            _enemySkill[1].UseSkill();   
        }
    }
}
