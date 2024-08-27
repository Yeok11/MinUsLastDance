using TMPro;
using UnityEngine;

public class EnemyActionText : MonoBehaviour
{
    private TextMeshProUGUI _actionText;
    public float _attack;
    public float _barrier;
    
    private void Awake()
    {
        _actionText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _actionText.text = "";
    }

    public void ActionMark(EnemyActionType type)
    {
        switch (type)
        {
            case EnemyActionType.Attack:
                _actionText.text = $"{_attack}";
                break;
            case EnemyActionType.Skill:
                _actionText.text = "스킬 발동";
                break;            
            case EnemyActionType.Barrier:
                _actionText.text = $"{_barrier}";
                break;
        }
    }
}
