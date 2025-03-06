using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stack_BombPassive : Shy_Stack_Effect
{
    private Health _playerHealth;
    private EJY_Enemy _enemy;

    private void Awake()
    {
        _playerHealth = FindObjectOfType<Shy_Player>().GetComponent<Health>();
    }

    private void Start()
    {
        _enemy = GetComponentInParent<EJY_Enemy>();
        GetComponentInChildren<TextMeshProUGUI>().text = "3";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(_enemy.gameObject.name);

        }
    }

    public override void DestroyEvent()
    {
        float addDamage = 7;
        _playerHealth.TakeDamage(addDamage + _enemy.stat._damage);
        _enemy.HealthCompo.TakeDamage(99999);
    }

    public override Shy_Stack_Effect Init(Transform _target)
    {
        Stack_BombPassive s = Instantiate(this, _target);
        s._playerHealth = FindObjectOfType<Shy_Player>().GetComponent<Health>();
        s._enemy = FindObjectOfType<EJY_Enemy>();
        s.actionType = STACKACTION_TYPE.PASSIVE;
        s.life = 3;

        return s;
    }

    public override void OnEffect()
    {

    }
}
