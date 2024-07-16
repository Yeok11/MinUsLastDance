using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    //순서 고임 해결 하기

    private int boardXlen = 6, boardYlen = 6;
    private int[,] board;
    private float boardX = -8.5f;
    private float boardY = -6.5f;
    private Vector3 boardPos;


    [SerializeField]
    private GameObject path, spawner;

    private void Awake()
    {
        boardXlen = 6; 
        boardYlen = 6;
        board = new int[boardXlen, boardYlen];
        boardX = -8.5f;
        boardY = -6.5f;
    }

    private void Start()
    {
        for (int i = 0; i < boardYlen; i++)
        {
            for (int j = 0; j < boardXlen; j++)
            {
                Debug.Log($"{j}, {i}에 소환");
                Instantiate(path);
                boardX = boardX + 2.5f;
                path.transform.position = new Vector3(boardX, boardY);
                spawner.transform.position = boardPos;
            }
            boardX = -8.5f;
            boardY = boardY + 2.5f;
        }
    }
}
