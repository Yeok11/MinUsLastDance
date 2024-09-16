using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_CardAddnDis : Shy_Deck
{
    [SerializeField] private GameObject _willChange;

    private int inputDice;
    private int outDice;

    private void OnMouseUp()
    {
        _willChange = gameObject;
    }

    private void AddCard(Shy_Deck deck)
    {
        deck.tileDeck.Insert(inputDice, deck.tileDeck[inputDice]);
    }
    private void DisCard(Shy_Deck deck)
    {
        deck.tileDeck.Remove(deck.tileDeck[outDice]);
    }

    public void InOdice()
    {

    }
}
