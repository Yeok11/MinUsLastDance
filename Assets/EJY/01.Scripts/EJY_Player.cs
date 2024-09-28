using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Purchasing;

public class EJY_Player : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private Shy_Manager_Move _moveManager;
    private Shy_Manager_Tile _tileManager;
    private Camera _mainCamera;

    private int _currentTileIdx = 24;
    private bool _isFighting;

    private List<Shy_Tile> _wasd;

    private void Awake()
    {
        _wasd = new List<Shy_Tile>();
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        _moveManager = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Move>();
        _tileManager = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Tile>();

        SetTile();
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

            Debug.Log("거리 계산");

            if (dis < min)
            {
                tileIdx = _tileManager.tileObjs.IndexOf(trms);
                min = dis;
            }

            Debug.Log($"{min}{tileIdx}");
        }

        if (tileIdx == -1) return;
        Move(tileIdx);

        Debug.Log("이동");
    }

    private void SetTile()
    {
        _wasd.Clear();

        if (_currentTileIdx - 7 >= 0)
            _wasd.Add(_tileManager.tileObjs[_currentTileIdx - 7]);
        else
            _wasd.Add(null);

        if (!((_currentTileIdx - 1) % 7 == 6 && _currentTileIdx % 7 == 0))
            _wasd.Add(_tileManager.tileObjs[_currentTileIdx - 1]);
        else
            _wasd.Add(null);

        if (_currentTileIdx + 7 <= 48)
            _wasd.Add(_tileManager.tileObjs[_currentTileIdx + 7]);
        else
            _wasd.Add(null);

        if (!((_currentTileIdx + 1) % 7 == 0 && _currentTileIdx % 7 == 6))
            _wasd.Add(_tileManager.tileObjs[_currentTileIdx + 1]);
        else
            _wasd.Add(null);
    }

    private void Move(int idx)
    {
        if (idx < 0 || idx >= 49) return;

        if (CanMove())
        {
            transform.position = _tileManager.tileObjs[idx].transform.position;
            _currentTileIdx = idx;
            SetTile();
        }
    }

    private bool CanMove()
    {
        if (_isFighting)
        {
            int movePoint = _moveManager.movePoint;

            return movePoint >= 0;
        }

        return true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
