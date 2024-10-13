using EJY;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static PlayerTargetting;

[RequireComponent(typeof(Health))]
public class EJY_Enemy : Shy_Character, IPointerClickHandler
{
    #region Ω∫≈»
    public int _level = 1;
    #endregion

    [SerializeField]internal List<Skill> _enemySkill;

    [SerializeField] protected EnemyStatSO _enemyStat;
    internal EnemyStatSO stat;

    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private Image guage;
    [SerializeField] private Image nextSkillSign;

    [SerializeField] private int useSkillNum;

    protected virtual void Awake()
    {
        HealthCompo = GetComponent<Health>();
        _enemySkill = GetComponentsInChildren<Skill>().ToList();

        Initialize();
        Debug.Log(stat._hp);
        Debug.Log(stat._damage);
    }

    
    private void Initialize()
    {
        #region Ω∫≈»
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

        hp = transform.Find("Bar").GetComponentInChildren<TextMeshProUGUI>();
        guage = transform.Find("Bar").Find("Guage").GetComponent<Image>();
        nextSkillSign = transform.Find("Icon").GetComponent<Image>();

        Health playerHealth = FindObjectOfType<Shy_Player>().GetComponent<Health>();
        #endregion

        for (int i = 0; i < _enemySkill.Count; i++)
        {
            _enemySkill[i]._enemyStatSO = stat;
            _enemySkill[i]._playHealth = playerHealth;
        }

        SetNextSkill();
    }

    private void Update()
    {
        hp.text = HealthCompo._currentHp + " / " + HealthCompo._maxHp;
        guage.fillAmount = HealthCompo._currentHp / HealthCompo._maxHp;
    }

    public void SetNextSkill()
    {
        useSkillNum = Random.Range(0, _enemySkill.Count);
        nextSkillSign.gameObject.SetActive(true);
        nextSkillSign.sprite = _enemySkill[useSkillNum].icon;
    }

    public void EnemyAction()
    {
        _enemySkill[useSkillNum].UseSkill();
        nextSkillSign.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectTarget(this);
    }

    public void Dead()
    {
        int enemyCnt = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().EnemyDestroy(this);

        if(enemyCnt == 0)
        {
            Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().UseEvent();
        }
        else
            PlayerTargetting.AutoEnemySet();

        Destroy(gameObject);
    }
}
