using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_DIceChanger : Shy_Dice
{
    [SerializeField] private List<GameObject> _diceArray;
    [SerializeField] private List<Transform> _transPos;
    [SerializeField] private GameObject slection;

    private int _diceInInventroy;

    private int _diceOnHand;

    private bool _changeDiceSel = false;

    private void Awake()
    {
        
    }
}