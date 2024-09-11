using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour 
{
    public float _maxHp;
    public float _currentHp;

    public float _addBarrier;
    public float _currentBarrier;

    public UnityEvent OnBarrierHitEvent;
    public UnityEvent OnDirectHitEvent;
    public UnityEvent OnDeadEvent;

    public void ResetHealth()
    {
        _currentHp = _maxHp;
        _currentBarrier = 0;
    }

    public void TakeDamage(float damage)
    {
        if (_currentBarrier > 0)
        {
            OnBarrierHitEvent?.Invoke();
            _currentBarrier -= damage;
            if (_currentBarrier < 0) _currentHp += _currentBarrier;
        }

        OnDirectHitEvent?.Invoke();
        _currentHp -= damage;

        if (_currentHp <= 0)
        {
            OnDeadEvent?.Invoke();
        }
    }
}
