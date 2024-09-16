using System.Data;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy/StatData")]
public class EnemyStatSO : ScriptableObject
{
    private static DataTable dt = new DataTable();
    [SerializeField] string atkFormula;
    [SerializeField] string hpFormula;
    public int _level = 1;
    public float _hp;
    public float _damage;
    public int _speed;

    public void LevelUp(int level) => _level += level;
    public void SetDamage()
    {
        if (atkFormula == "") return;
        atkFormula.Replace("f","");
        _damage = float.Parse(dt.Compute(atkFormula, "").ToString());
    }
    public void SetHP()
    {
        if (hpFormula == "") return;
        hpFormula.Replace("f", "");
        _hp = float.Parse(dt.Compute(hpFormula, "").ToString());
    }
}