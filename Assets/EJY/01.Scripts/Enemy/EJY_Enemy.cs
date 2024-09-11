using EJY;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static PlayerTargetting;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Health))]
public abstract class EJY_Enemy : MonoBehaviour, IPointerClickHandler
{
    #region ½ºÅÈ
    public int _level;

    public int speed;
    protected float _attack;
    public float Attack => _attack;
    protected float _barrier;
    #endregion

    protected Skill[] _enemySkill;

    [SerializeField] protected EnemyStatSO _enemyStat;
    public EnemyStatSO stat;

    public Health HealthCompo {  get; protected set; }

    protected virtual void Awake()
    {
        HealthCompo = GetComponent<Health>();
        _enemySkill = GetComponentsInChildren<Skill>();

        stat = ScriptableObject.CreateInstance<EnemyStatSO>();
        stat = _enemyStat;
        Initialize();
    }

    
    private void Initialize()
    {
        HealthCompo._maxHp = _enemyStat._hp;
        _attack = _enemyStat._damage;
        speed = _enemyStat._speed;
    }

    protected abstract void EnemyAttack();


    protected abstract void EnemySkill();









    public void OnPointerClick(PointerEventData eventData)
    {
        SelectTarget(this);
    }
}
