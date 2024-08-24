using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shy_Dice : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Shy_DiceSO dice;
    private Shy_Manager_Dice diceManager;
    public int value;

    private void Start()
    {
        diceManager = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Dice>();
        dice = Shy_Manager.instance.gameObject.GetComponentInChildren<Shy_Deck>().diceDeck[transform.GetSiblingIndex()];

        value = dice.eyes[0];
    }

    private void Roll()
    {
        diceManager.ActionPoint -= dice.cost;

        int num = Random.Range(0, 6);

        value = dice.eyes[num];

        diceManager.movePoint += value;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click dice : " + gameObject.name);
        if (diceManager.ActionPoint >= dice.cost && diceManager.movePoint == 0)
        {
            Roll();
        }
        else
        {
            Debug.Log("dice Error : " + gameObject.name);
        }
    }
}
