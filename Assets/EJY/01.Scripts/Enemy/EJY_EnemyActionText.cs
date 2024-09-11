using TMPro;
using UnityEngine;

public class EnemyActionText : MonoBehaviour
{
    [SerializeField] private EJY_Enemy _enemy;
    private TextMeshProUGUI _actionText;
    private float _attack;
    private float _barrier;
    
    private void Awake()
    {
        _actionText = GetComponent<TextMeshProUGUI>();
        _enemy = GetComponent<EJY_Enemy>();
    }

    private void Start()
    {
        _attack = _enemy.Attack;
        _barrier = _enemy.Barrier;
    }

    public void ActionMark(EnemyActionType type)
    {
        switch (type)
        {
            case EnemyActionType.Attack:
                _actionText.text = $"{_attack}";
                break;
            case EnemyActionType.Skill:
                _actionText.text = "��ų �ߵ�";
                break;            
            case EnemyActionType.Barrier:
                _actionText.text = $"{_barrier}";
                break;
        }
    }
}
