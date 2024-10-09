using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarrierText : MonoBehaviour
{
    private Health _health;
    private TextMeshProUGUI _barrierText;

    private void Awake()
    {
        _health = GetComponentInParent<Health>();
        _barrierText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void TextChange(float barrier)
    {
        _barrierText.text = barrier.ToString();
    }
}
