using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : EJY_Enemy
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void EnemyAttack()
    {
        // ���߿� �÷��̾�� ���� �̵��� ����
    }

    protected override void EnemyBarrier()
    {
        HealthCompo._currentBarrier += _barrier;
    }

    protected override void EnemySkill()
    {

    }

    protected override void FindTarget()
    {

    }
}
