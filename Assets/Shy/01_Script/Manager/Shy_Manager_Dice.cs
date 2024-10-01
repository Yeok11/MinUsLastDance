using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shy_Manager_Dice : MonoBehaviour
{
    public List<Shy_Dice> diceList;

    public void AllDiceRoll()
    {
        for (int i = 0; i < diceList.Count; i++)
        {
            diceList[i].Roll(false);
        }
    }
}
