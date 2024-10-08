using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Shy/Dice")]
public class Shy_DiceSO : Shy_Obj
{
    public List<int> eyes = new List<int>(6);
    public int cost;
}
