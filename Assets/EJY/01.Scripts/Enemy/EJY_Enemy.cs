using EJY;
using UnityEngine;
using UnityEngine.EventSystems;
using static PlayerTargetting;

[RequireComponent(typeof(Health))]
public abstract class EJY_Enemy : Shy_Character, IPointerClickHandler
{
    #region Ω∫≈»
    public int _level;
    #endregion

    [SerializeField]protected Skill[] _enemySkill;

    [SerializeField] protected EnemyStatSO _enemyStat;
    internal EnemyStatSO stat;

    protected virtual void Awake()
    {
        HealthCompo = GetComponent<Health>();
        _enemySkill = GetComponentsInChildren<Skill>();

        Initialize();
        Debug.Log(stat._hp);
        Debug.Log(stat._damage);
    }

    
    private void Initialize()
    {
        stat = ScriptableObject.CreateInstance<EnemyStatSO>();
        stat.atkFormula = _enemyStat.atkFormula;
        stat.hpFormula = _enemyStat.hpFormula;
        stat._speed = _enemyStat._speed;
        stat.LevelUp(_level);
        stat._damage = stat.SetStat(stat.atkFormula,stat._damage);
        stat._hp = stat.SetStat(stat.hpFormula,stat._hp);

        HealthCompo._maxHp = stat._hp;
        HealthCompo._currentHp = stat._hp;
    }

    protected abstract void EnemyAction();

   

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectTarget(this);
    }
}
