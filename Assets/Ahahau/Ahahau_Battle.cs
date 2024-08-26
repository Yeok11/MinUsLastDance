using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ahahau_Battle : MonoBehaviour
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
    public bool PlayerTurn { get; set; }

    private bool turn;
    public int MovePoint { get; set; }

    private void Awake()
    {
        MovePoint = 1;
    }

    private void Update()
    {
        if (PlayerTurn && turn)
        {
            playerDack.Add(addDack[Random.Range(0, addDack.Count)]);
            playerDack.Add(addDack[Random.Range(0, addDack.Count)]);
            playerDack.Add(addDack[Random.Range(0, addDack.Count)]);
            turn = false;
        }


        if (MovePoint <= 0)
        {
            PlayerTurn = false;
        }
        if (_playerCardUse[0] == true && playerDack[0] >= playerDack.Count)
        {
            MovePoint += playerDack[0];
        }
        if (_playerCardUse[1] == true && playerDack[1] >= playerDack.Count)
        {
            MovePoint += playerDack[1];
        }
        if (_playerCardUse[2] == true && playerDack[2] >= playerDack.Count)
        {
            MovePoint += playerDack[2];
        }
    }

}
