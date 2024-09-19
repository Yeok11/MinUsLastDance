using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class StandardEnemy : EJY_Enemy
    {
        protected override void EnemyAction()
        {
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                if (_enemySkill[0].CanUseSkill())
                {
                    _enemySkill[0].UseSkill();
                }
            if (Input.GetKeyDown(KeyCode.Alpha2))
                if (_enemySkill[1].CanUseSkill())
                {
                    _enemySkill[1].UseSkill();
                }
        }
    }
}

