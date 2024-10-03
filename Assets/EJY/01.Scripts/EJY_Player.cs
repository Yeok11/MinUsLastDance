using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Purchasing;

public class EJY_Player : MonoBehaviour ,IDragHandler, IEndDragHandler
{
    private Shy_Manager_Move _moveManager;
    private Shy_Manager_Tile _tileManager;
    private Camera _mainCamera;

    private int _currentTileIdx = 24;
    public bool _isFighting;

    private Shy_Tile[] _wasd = new Shy_Tile[4];
    private List<Shy_Tile> _moved;

    private Vector3 _currentPos;
    [SerializeField] private float _limitDis = 1.2f;

    private void Awake()
    {
        _mainCamera = Camera.main;

        _moved = new List<Shy_Tile>();
    }

    
    public void Init()
    {
        _moveManager = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Move>();
        _tileManager = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Tile>();

        SetTile();

        Move(_currentTileIdx,false);
        _currentPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(_currentTileIdx - 7);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if ((_currentTileIdx - 1) % 7 == 6 && _currentTileIdx % 7 == 0) return;
            Move(_currentTileIdx - 1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Move(_currentTileIdx + 7);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if ((_currentTileIdx + 1) % 7 == 0 && _currentTileIdx % 7 == 6) return;
            Move(_currentTileIdx + 1);
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 _worldPos = _mainCamera.ScreenToWorldPoint(new Vector2(eventData.position.x, eventData.position.y));
        transform.position = _worldPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       float  distance = Vector2.Distance(_currentPos, transform.position);

        if (distance > _limitDis)
        {
            ReturnCurrentTile();
            Debug.Log("이동거리 벗어남");
            return;
        }

        Debug.Log("드래그");
        SetPlayerPosWithTile();
    }
    
    private void ReturnCurrentTile()
    {
        if (_isFighting)
            _moveManager.movePoint++;

        Move(_currentTileIdx,false);
    }

    private void SetPlayerPosWithTile()
    {
        float min = float.MaxValue;
        int tileIdx = -1;

        foreach (var trms in _wasd)
        {
            if(trms is null) continue;

            float dis = Vector2.Distance(transform.position, trms.transform.position);

            if (dis < min)
            {
                tileIdx = _tileManager.tileObjs.IndexOf(trms);
                min = dis;
            }
        }

        if (tileIdx == -1) return;
        
        if (!CanMove(tileIdx))
        {
            Debug.Log($"이미 감");
            ReturnCurrentTile();
            return;
        }

        Debug.Log("이동");
        Move(tileIdx);
    }

    private void SetTile()
    {
        Shy_Tile[] tiles = new Shy_Tile[4];

        if (_currentTileIdx - 7 >= 0)
            tiles[0] = _tileManager.tileObjs[_currentTileIdx - 7];

        if (!((_currentTileIdx - 1) % 7 == 6 && _currentTileIdx % 7 == 0))
            tiles[1] = _tileManager.tileObjs[_currentTileIdx - 1];

        if (_currentTileIdx + 7 <= 48)
            tiles[2] = _tileManager.tileObjs[_currentTileIdx + 7];

        if (!((_currentTileIdx + 1) % 7 == 0 && _currentTileIdx % 7 == 6))
            tiles[3] = _tileManager.tileObjs[_currentTileIdx + 1];

        _wasd = tiles;
    }

    private void Move(int idx, bool isAdd = true)
    {
        if (idx < 0 || idx >= 49) return;

        Shy_Tile tile = _tileManager.tileObjs[idx];

        if (CanMove(idx))
        {
            if (_isFighting)
                _moveManager.movePoint--;
            if (isAdd)
                _moved.Add(tile);
            if (_moveManager.movePoint <= 0) _moved.Clear();

            _currentPos = tile.transform.position;
            _currentTileIdx = idx;
            transform.position = _currentPos;
            SetTile();
        }
    }

    private bool CanMove(int idx)
    {
        if (_isFighting)
        {
            if (idx == _currentTileIdx) return true;
            return _moveManager.movePoint > 0 && !(_moved.Contains(_tileManager.tileObjs[idx]));
        }

        return true;
    }
}
