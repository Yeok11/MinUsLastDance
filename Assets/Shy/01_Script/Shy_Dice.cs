using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shy_Dice : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Shy_DiceSO dice;
    [SerializeField] private TextMeshProUGUI valueText;
    private Shy_Manager_Move diceManager;
    public int value;
    internal int bonusValue;

    private void Start()
    {
        diceManager = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Move>();
        dice = Shy_Manager.instance.gameObject.GetComponentInChildren<Shy_Deck>().diceDeck[transform.GetSiblingIndex()];

        DiceInit();
    }

    private void DiceInit()
    {
        value = dice.eyes[0];
        bonusValue = 0;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dice.cost.ToString();
        UpdateText();
    }

    private void UpdateText()
    {
        valueText.SetText(value.ToString());
    }

    public void Roll(bool _useCost = true)
    {
        if(_useCost)
            diceManager.ActionPoint -= dice.cost;

        int num = Random.Range(0, 6);

        value = dice.eyes[num];

        value += bonusValue;

        if(value <= 0)
        {
            value = 1;
        }

        UpdateText();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click dice : " + gameObject.name);
        if (diceManager.ActionPoint >= dice.cost && diceManager.movePoint == 0)
        {
            diceManager.movePoint += value;
            Roll();
        }
        else
        {
            Debug.Log("dice Error : " + gameObject.name);
        }
    }
}
