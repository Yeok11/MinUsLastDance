using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private BarrierText _barrierText;

    public float _maxHp;
    public float _currentHp;

    public float _currentBarrier = 0;

    public UnityEvent OnBarrierHitEvent;
    public UnityEvent<float> OnDirectHitEvent;
    public UnityEvent OnDeadEvent;

    public void TakeDamage(float damage)
    {
        if (_currentBarrier > 0)
        {
            OnBarrierHitEvent?.Invoke();
            _currentBarrier -= damage;

            if (_currentBarrier < 0)
            {
                _currentHp += _currentBarrier;
                _currentBarrier = 0;
            }
            else
            {
                _barrierText?.TextChange(_currentBarrier);
                return;
            }

            _barrierText?.TextChange(_currentBarrier);
        }

        OnDirectHitEvent?.Invoke(damage);

        _currentHp -= damage;

        if (_currentHp <= 0)
        {
            _currentHp = 0;
            OnDeadEvent?.Invoke();
        }
    }

    public void GetBarrier(float weightBarrier)
    {
        _currentBarrier += weightBarrier;
        _currentBarrier = Mathf.RoundToInt(_currentBarrier);
        _barrierText?.TextChange(_currentBarrier);
    }
}
