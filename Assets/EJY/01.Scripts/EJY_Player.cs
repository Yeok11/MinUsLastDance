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

    private Vector3 _currentPos;
    [SerializeField] private float _limitDis = 1.2f;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        _moveManager = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Move>();
        _tileManager = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Tile>();

        SetTile();

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
       float  distance = Vector3.Distance(_currentPos, transform.position);

        if (distance > _limitDis || !CanMove())
        {
            if(_isFighting)
            _moveManager.movePoint++;
            Move(_currentTileIdx);
            return;
        }

        SetPlayerPosWithTile();
    }

    private void SetPlayerPosWithTile()
    {
        float min = float.MaxValue;
        int tileIdx = -1;

        foreach (var trms in _wasd)
        {
            if(trms is null) continue;

            float dis = Vector3.Distance(transform.position, trms.transform.position);

            if (dis < min)
            {
                tileIdx = _tileManager.tileObjs.IndexOf(trms);
                min = dis;
            }
        }

        if (tileIdx == -1) return;
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

    private void Move(int idx)
    {
        if (idx < 0 || idx >= 49) return;

        if (CanMove())
        {
            if (_isFighting) _moveManager.movePoint--;

            transform.position = _tileManager.tileObjs[idx].transform.position;
            _currentTileIdx = idx;
            _currentPos = transform.position;
            SetTile();
        }
    }

    private bool CanMove()
    {
        if (_isFighting)
        {
            return _moveManager.movePoint > 0;
        }

        return true;
    }

}
