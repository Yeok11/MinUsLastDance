using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ah_PlayerMove : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Camera _mainCamera;
    private bool _playerCanMove = false;
    private bool _dragEnd = false;
    private int playerCurPos;
    public int _movePoint;
    [SerializeField] private List<Ahahau_TileClick> _boardImages = new List<Ahahau_TileClick>();
    private Vector2 _playerKeyInput;
    private Vector3 _playerFirstPos;
    private void Start()
    {
        _mainCamera = Camera.main;
        playerCurPos = 24;
        for (int i = 0; i < _boardImages.Count; i++) _boardImages[i]._tileNum = i;
    }
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        _playerKeyInput = new Vector2(x, y);
        PlayerMoveToKey();
    }

    private void ColorChange(Color color)
    {
        int[] tileCondition = { -1, 1, -7, 7 };
        foreach (int i in tileCondition)
        {
            int colorTile = playerCurPos + i;

            if (colorTile >= 0 && colorTile < _boardImages.Count && (i == -7 || i == 7 || (playerCurPos / 7 == colorTile / 7)))
            {
                _boardImages[colorTile].GetComponent<Image>().color = color;
            }
        }
    }

    public void PlayerMoveToInt(int _tileNum = 24)
    {
        if (_playerCanMove == false) return;

        transform.position = _boardImages[_tileNum].transform.position;

        ColorChange(Color.white);
        _movePoint--;
        playerCurPos = _tileNum;
        _playerCanMove = false;
    }
    public void PlayerMoveToKey()
    {
        if (_playerCanMove == false) return;       
        int nextTileNum = playerCurPos;
        float x = _playerKeyInput.x;
        float y = _playerKeyInput.y;
        if(x != 0 || y != 0)
        {
            nextTileNum += (int)x;
            nextTileNum -= (7 * (int)y);
            if (_boardImages[nextTileNum].GetComponent<Image>().color == Color.green)
            {
                transform.position = _boardImages[nextTileNum].transform.position;
                ColorChange(Color.white);
                playerCurPos = nextTileNum;
                _playerCanMove = false;
                _movePoint--;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _playerCanMove = !_playerCanMove;
        if (_movePoint > 0)
        {
            ColorChange(Color.green);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_playerCanMove == false) return;
        _playerFirstPos = transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (_playerCanMove == false) return;
        Vector3 _worldPosition = _mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, _mainCamera.nearClipPlane));
        transform.position = new Vector3(_worldPosition.x, _worldPosition.y, 0);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _dragEnd = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {if(!_dragEnd) return;
        if (collision.gameObject.GetComponent<Image>().color == Color.green)
        {
            _dragEnd = false;
            _playerCanMove = false;
            ColorChange(Color.white);
            for(int i = 0; i < _boardImages.Count; i++)
            {
                if(collision.gameObject.name == _boardImages[i].name)
                {
                    playerCurPos = i;
                    transform.position = _boardImages[i].transform.position;
                    print(i);
                    break;
                }
            }
            _movePoint--;                
        }
         else
        {
            transform.position = _playerFirstPos;
            _dragEnd = false;
        }
    }
}
