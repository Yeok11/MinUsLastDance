using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class BossEnemy_ElectricFrog : EJY_Enemy
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
            if (Input.GetKeyDown(KeyCode.Alpha3))
                if (_enemySkill[2].CanUseSkill())
                {
                    _enemySkill[2].UseSkill();
                }
        }
    }
}