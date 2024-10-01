using TMPro;
using UnityEngine;

public class EnemyActionText : MonoBehaviour
{
    [SerializeField] private EJY_Enemy _enemy;
    private TextMeshProUGUI _actionText;
    private float _attack;
    
    private void Awake()
    {
        _actionText = GetComponent<TextMeshProUGUI>();
        _enemy = GetComponent<EJY_Enemy>();
    }

    private void Start()
    {
    }
}
