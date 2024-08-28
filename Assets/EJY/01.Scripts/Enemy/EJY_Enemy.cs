using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static Targetting;
using Random = UnityEngine.Random;

public enum EnemyActionType
{
    Attack, Barrier, Skill
}

[RequireComponent(typeof(Health))]
public abstract class EJY_Enemy : MonoBehaviour, IPointerClickHandler
{
    public int speed;
    protected float _attack;
    public float Attack => _attack;
    protected float _barrier;
    public float Barrier => _barrier;
    protected int _target;
    protected EnemyActionType _actionType;

    protected bool _isDead;

    protected GameObject[] _targets;

    [SerializeField] protected EnemyStatSO _enemyStat;

    public Health HealthCompo {  get; protected set; }

    protected virtual void Awake()
    {
        HealthCompo = GetComponent<Health>();
        Initialize();
    }

    protected virtual void Start()
    {
        _targets = new GameObject[_target];
        EnemyAction();
    }

    protected abstract void FindTarget();

    private void Initialize()
    {
        HealthCompo._maxHp = _enemyStat._hp;
        HealthCompo._addBarrier = _enemyStat._barrier;
        _attack = _enemyStat._attack;
        _target = _enemyStat._targets;
        speed = _enemyStat._speed;
        Reset();
    }

    protected void Reset()
    {
        HealthCompo.ResetHealth();
        _isDead = false;
    }

    protected void EnemyAction()
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
        }
    }

    protected abstract void EnemyAttack();

    protected abstract void EnemyBarrier();

    protected abstract void EnemySkill();

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectTarget(this);
    }
}
