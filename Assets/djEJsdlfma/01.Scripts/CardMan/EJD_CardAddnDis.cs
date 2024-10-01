using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_CardAddnDis : Shy_Deck
{
    [SerializeField] private Shy_TileSO _willTileChange;
    [SerializeField] private Shy_DiceSO _willDiceChange;
    private Shy_Dice _diceChange;
    private Shy_Deck _deckChange;

    private int inputDeck;
    private int outDeck;

    private void OnMouseUp()
    {
        inputDeck = instance.tileDeck.IndexOf(_willTileChange);
    }

    private void Update()
    {
        
    }

/*    private void AddCard(Shy_Deck deck)
    {
        deck.tileDeck.Insert(inputDeck, deck.tileDeck[inputDeck]);
    }
    private void DisCard(Shy_Deck deck)
    {
        deck.tileDeck.Remove(deck.tileDeck[outDeck]);
    }*/

    private void AddnDisCard(Shy_Deck deck)
    {
        deck.tileDeck.Remove(deck.tileDeck[outDeck]);
        deck.tileDeck.Insert(inputDeck, deck.tileDeck[inputDeck]);
    }

    private void AddDice(Shy_Deck dice)
    {
        dice.tileDeck.Insert(inputDeck, dice.tileDeck[inputDeck]);
    }

    private void DIsDice(Shy_Deck dice)
    {
        dice.tileDeck.Remove(dice.tileDeck[outDeck]);
    }
}
