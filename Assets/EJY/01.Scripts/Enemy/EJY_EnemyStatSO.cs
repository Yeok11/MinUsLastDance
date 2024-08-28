using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy/StatData")]
public class EnemyStatSO : ScriptableObject
{
    public float _hp;
    public float _attack;
    public float _barrier;
    public int _targets;
    public int _speed;
}
