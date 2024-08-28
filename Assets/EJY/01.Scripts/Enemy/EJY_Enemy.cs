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
public abstract class Enemy : MonoBehaviour, IPointerClickHandler
{
    protected float _attack;
    public float Attack => _attack;
    protected float _barrier;
    public float Barrier => _barrier;
    protected EnemyActionType _actionType;

    protected bool _isDead;

    [SerializeField] protected EnemyStatSO _enemyStat;

    public Health HealthCompo {  get; protected set; }
    public EnemyActionText EnemyTextCompo { get; protected set; }

    protected virtual void Awake()
    {
        HealthCompo = GetComponent<Health>();
        EnemyTextCompo = transform.Find("ActionText").gameObject.GetComponent<EnemyActionText>();
        Initialize();
    }

    protected virtual void Start()
    {
        EnemyTextCompo._attack = _attack;
        EnemyTextCompo._barrier = _barrier;
        EnemyAction();
    }

    protected abstract void FindTarget();

    private void Initialize()
    {
        HealthCompo._maxHp = _enemyStat._hp;
        HealthCompo._addBarrier = _enemyStat._barrier;
        _attack = _enemyStat._attack;
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

        EnemyTextCompo.ActionMark(_actionType);

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
