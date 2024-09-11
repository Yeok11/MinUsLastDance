using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_StageSpawner : MonoBehaviour
{
    private int boardXlen = 7, boardYlen = 7;
    private int[,] board;
    private float boardX = -8.5f;
    private float boardY = -6.5f;
    private Vector3 boardPos;

    [SerializeField] private List<GameObject> boardLand;
    [SerializeField] private List<GameObject> tiles;

    private int a = 0;

    private int val = 0;

    private void Awake()
    {
        boardXlen = 7;
        boardYlen = 7;
        board = new int[boardXlen, boardYlen];
        boardX = -8.5f;
        boardY = -6.5f;
    }
    
    private static int[,,] Board = new int[1, 7, 7]
    {
        {
            {0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0 },
            {0,0,0,0,1,0,0 },
            {0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0 }
        }
    };

    private void Start()
    {
        for (int i = 0; i < boardYlen; i++)
        {
            for (int j = 0; j < boardXlen; j++)
            {
                Debug.Log($"{j}, {i}¿¡ ¼ÒÈ¯");
                switch((int)Board.GetValue(1, j , i))
                {
                    case 0:
                        Instantiate(tiles[0],boardLand[val].transform);
                        break;
                    case 1:
                        Instantiate(tiles[1], boardLand[val].transform);
                        break;
                    case 2:
                        Instantiate(tiles[2], boardLand[val].transform);
                        break;
                    case 3:
                        Instantiate(tiles[3], boardLand[val].transform);
                        break;
                }
                /*boardX = boardX + 2.5f;
                path.transform.position = new Vector3(boardX, boardY);
                spawner.transform.position = boardPos;*/
                val++;
            }
            /*boardX = -8.5f;
            boardY = boardY + 2.5f;*/
        }
    }


}