using System.Data;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy/StatData")]
public class EnemyStatSO : ScriptableObject
{
    private static DataTable dt = new DataTable();
    public string atkFormula = "";
    public string hpFormula = "";
    public int _level = 0;
    public float _hp;
    public float _damage;
    public int _speed;

    public void LevelUp(int level) => _level += level;
    public float SetStat(string formula, float stat)
    {
        if (formula == "") return 0;
        formula = formula.Replace("level",_level.ToString());
        formula = formula.Replace("f","");
        return stat = float.Parse(dt.Compute(formula, "").ToString());
    }
}