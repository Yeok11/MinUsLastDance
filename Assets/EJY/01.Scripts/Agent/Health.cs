using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _damageText;

    public float _maxHp;
    public float _currentHp;

    public float _currentBarrier = 0;

    public UnityEvent OnBarrierHitEvent;
    public UnityEvent OnDirectHitEvent;
    public UnityEvent OnDeadEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("�Է�");
            OnDirectHitEvent?.Invoke();
        }
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

    public void GetBarrier(float weightBarrier)
    {
        if (_currentBarrier > weightBarrier)
            return;
        _currentBarrier = weightBarrier;
    }

    private void ShowDamageText(float damage)
    {
        _damageText.gameObject.SetActive(true);
        _damageText.text = damage.ToString();

    }
}
