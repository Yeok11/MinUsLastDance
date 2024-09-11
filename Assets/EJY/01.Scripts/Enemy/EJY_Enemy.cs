using EJY;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static PlayerTargetting;
using Random = UnityEngine.Random;

public enum EnemyActionType
{
    Attack, Barrier, Skill
}

[RequireComponent(typeof(Health))]
public abstract class EJY_Enemy : Shy_Character, IPointerClickHandler
{
    public int speed;
    protected float _attack;
    public float Attack => _attack;
    protected float _barrier;
    /* public float Barrier => _barrier;
     protected int _target;
     protected EnemyActionType _actionType;

     protected bool _isDead;*/

    protected Skill[] _enemySkill;

    [SerializeField] protected EnemyStatSO _enemyStat;

    internal EnemyStatSO stat;

    protected virtual void Awake()
    {
        HealthCompo = GetComponent<Health>();
        _enemySkill = GetComponentsInChildren<Skill>();
    }

    protected virtual void Start()
    {
        /*_targets = new GameObject[_target];
        EnemyAction();*/
        stat = ScriptableObject.CreateInstance<EnemyStatSO>();
        stat = _enemyStat;
        Initialize();
    }

    //protected abstract void FindTarget();

    private void Initialize()
    {
        HealthCompo._maxHp = _enemyStat._hp;
        //HealthCompo._addBarrier = _enemyStat._barrier;
/*        _attack = _enemyStat._attack;
        _target = _enemyStat._targets;*/
        speed = _enemyStat._speed;
  /*      Reset();
    }

    protected void Reset()
    {
        HealthCompo.ResetHealth();
        _isDead = false;
    }

    protected abstract void EnemyAction()
    {
        _actionType = (EnemyActionType)Random.Range(0, 3);

        Debug.Log(_actionType);

        switch (_actionType)
        {
            case EnemyActionType.Attack:
                EnemyAttack();
                break;
            case EnemyActionType.Barrier:
                EnemyBarrier();
                break;
            case EnemyActionType.Skill:
                EnemySkill();
                break;
        }*/
    }

    protected abstract void EnemyAttack();

    protected abstract void EnemyBarrier();

    protected abstract void EnemySkill();

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectTarget(this);
    }
}
