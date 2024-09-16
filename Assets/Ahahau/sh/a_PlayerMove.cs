using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class a_PlayerMove : MonoBehaviour
{
    public static a_PlayerMove instance;

    public bool playerCanMove = false;
    public int playerCurPos;
    public int movePoint;
    [SerializeField] private List<Ahahau_TileClick> boardImages = new List<Ahahau_TileClick>();
    [SerializeField] private a_Player player;
    Vector2 playerKeyInput;
    
    private void Awake()
    {
        #region single
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        #endregion
    }

    private void Start()
    {
        playerCurPos = 24;
        movePoint = 99;
        for (int i = 0; i < boardImages.Count; i++) boardImages[i].tileNum = i;
        PlayerMoveToInt();
    }
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        playerKeyInput = new Vector2(x, y);
        PlayerMoveToKey();
    }

    private void ColorChange(Color color)
    {
        print(playerCurPos);
        int[] tileCondition = { -1, 1, -7, 7 };

        foreach (int i in tileCondition)
        {
            int colorTile = playerCurPos + i;

            if (colorTile >= 0 && colorTile < boardImages.Count && (i == -7 || i == 7 || (playerCurPos / 7 == colorTile / 7)))
            {
                boardImages[colorTile].GetComponent<Image>().color = color;
            }
        }
    }

    public void CheckCanMove()
    {
        //Á¶°Ç
        
        playerCanMove = !playerCanMove;
        if (movePoint > 0)
        {
            ColorChange(Color.green);
        }
        //color
    }

    public void PlayerMoveToInt(int _tileNum = 24)
    {
        if (playerCanMove == false) return;

        player.transform.position = boardImages[_tileNum].transform.position;

        ColorChange(Color.white);
        movePoint--;
        playerCurPos = _tileNum;
        playerCanMove = false;
    }
    public void PlayerMoveToKey()
    {
        if (playerCanMove == false) return;       
        int nextTileNum = playerCurPos;
        float x = playerKeyInput.x;
        float y = playerKeyInput.y;
        if(x != 0 || y != 0)
        {
            nextTileNum += (int)x;
            nextTileNum -= (7 * (int)y);
            if (boardImages[nextTileNum].GetComponent<Image>().color == Color.green)
            {
                player.transform.position = boardImages[nextTileNum].transform.position;
                ColorChange(Color.white);
                playerCurPos = nextTileNum;
                playerCanMove = false;
                movePoint--;
            }
        }
    }
    public void PlayerMoveToDrag(Transform currentTile)
    {
        foreach (Ahahau_TileClick imgPos in boardImages)
        {
            if(imgPos.transform.position == currentTile.transform.position)
            {
                ColorChange(Color.white);
                playerCurPos = imgPos.tileNum;
                playerCanMove = false;
                movePoint--;
            }
        }
    }
}
