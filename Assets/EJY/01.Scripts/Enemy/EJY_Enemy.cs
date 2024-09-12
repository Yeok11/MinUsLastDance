using EJY;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static PlayerTargetting;

[RequireComponent(typeof(Health))]
public abstract class EJY_Enemy : Shy_Character, IPointerClickHandler
{
    #region Ω∫≈»
    public int _level;

    protected float _damage;
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
        stat.LevelUp(_level);
        Initialize();
    }

    
    private void Initialize()
    {
        HealthCompo._maxHp = _enemyStat._hp;
        HealthCompo._currentHp = _enemyStat._hp;
        //_damage = _enemyStat._level * ;
    }

    protected abstract void EnemyAction();

   

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectTarget(this);
    }
}
