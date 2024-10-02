using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Battle : MonoBehaviour
{
    [SerializeField] private List<int> addDack = new List<int>();
    private List<int> playerDack = new List<int>();
    private bool[] _playerCardUse = { false, false, false };

    public bool this[int index]
    {
        get
        {
            return _playerCardUse[index];
        }
        set
        {
            _playerCardUse[index] = value;
        }
    }
    public bool playerTurn { get; set; }

    private bool turn;
    

    private void Awake()
    {
       
    }

    private void Update()
    {
        if (playerTurn && turn)
        {
            playerDack.Add(addDack[Random.Range(0, addDack.Count)]);
            playerDack.Add(addDack[Random.Range(0, addDack.Count)]);
            playerDack.Add(addDack[Random.Range(0, addDack.Count)]);
            turn = false;
        }


        //if (a_PlayerMove.instance.movePoint <= 0)
        //{
        //    playerTurn = false;
        //}
        //if (_playerCardUse[0] == true && playerDack[0] >= playerDack.Count)
        //{
        //    a_PlayerMove.instance.movePoint += playerDack[0];
        //}
        //if (_playerCardUse[1] == true && playerDack[1] >= playerDack.Count)
        //{
        //    a_PlayerMove.instance.movePoint += playerDack[1];
        //}
        //if (_playerCardUse[2] == true && playerDack[2] >= playerDack.Count)
        //{
        //    a_PlayerMove.instance.movePoint += playerDack[2];
        //}
    }

}
