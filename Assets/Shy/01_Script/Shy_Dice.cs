using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shy_Dice : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Shy_DiceSO dice;
    public int value;

    private void Awake()
    {
        value = dice.eyes[0];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int num = Random.Range(0, 6);

        value = dice.eyes[num];
    }
}
