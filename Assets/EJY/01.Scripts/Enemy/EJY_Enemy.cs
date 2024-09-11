using EJY;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static PlayerTargetting;

[RequireComponent(typeof(Health))]
public abstract class EJY_Enemy : Shy_Character, IPointerClickHandler
{
    #region ½ºÅÈ
    public int _level;

    public int speed;
    protected float _attack;
    public float Attack => _attack;
    protected float _barrier;
    #endregion

    [SerializeField]protected Skill[] _enemySkill;

    [SerializeField] protected EnemyStatSO _enemyStat;
    internal EnemyStatSO stat;

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

    protected abstract void EnemyAction();









    public void OnPointerClick(PointerEventData eventData)
    {
        SelectTarget(this);
    }
}
