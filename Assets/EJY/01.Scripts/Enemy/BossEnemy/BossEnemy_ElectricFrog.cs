using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class BossEnemy_ElectricFrog : EJY_Enemy
    {
        protected override void EnemyAction()
        {
            if(_enemySkill[1].CanUseSkill())
            {
                _enemySkill[1].UseSkill();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                EnemyAction();
        }
    }
}