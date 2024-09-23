using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_BombPassive : Shy_Stack_Effect
{
    private Health _playerHealth;
    private EnemyStatSO _enemyStatSO;

    public override void DestroyEvent()
    {
        life = 3;
    }

    public override Shy_Stack_Effect Init(Transform _target)
    {
        Stack_BombPassive s = Instantiate(this,_target);
        s._playerHealth = FindObjectOfType<Shy_Player>().GetComponent<Health>();
        s._enemyStatSO = FindObjectOfType<EJY_Enemy>().stat;
        s.actionType = STACKACTION_TYPE.PASSIVE;
        s.life = 3;

        return s;
    }

    public override void OnEffect()
    {
        float addDamage = 7;
        _playerHealth.TakeDamage(addDamage + _enemyStatSO._damage);
    }
}
