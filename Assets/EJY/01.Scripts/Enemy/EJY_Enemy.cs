using EJY;
using UnityEngine;
using UnityEngine.EventSystems;
using static PlayerTargetting;

[RequireComponent(typeof(Health))]
public class EJY_Enemy : Shy_Character, IPointerClickHandler
{
    #region ����
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

        if (stat.atkFormula is not "")
            stat._damage = stat.SetStat(stat.atkFormula, stat._damage);
        else
            stat._damage = _enemyStat._damage;
        if(stat.hpFormula is not "")
        stat._hp = stat.SetStat(stat.hpFormula,stat._hp);
        else
            stat._hp = _enemyStat._hp;

        HealthCompo._maxHp = stat._hp;
        HealthCompo._currentHp = stat._hp;
    }

    private void Update()
    {
    }

    public void EnemyAction()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectTarget(this);
    }
}
