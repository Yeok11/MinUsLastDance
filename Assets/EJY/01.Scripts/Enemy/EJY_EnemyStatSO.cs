using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy/StatData")]
public class EnemyStatSO : ScriptableObject
{
    public int _level = 1;
    public float _hp;
    public float _damage;
    public int _speed;

    public void LevelUp(int level) => _level += level;
    public void SetDamage()
    {
        //_damage = _level *
    }
}