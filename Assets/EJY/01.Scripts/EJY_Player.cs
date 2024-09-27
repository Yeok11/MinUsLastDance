using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Purchasing;

public class EJY_Player : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private List<Transform> _tileTrmList;
    private Shy_Manager_Move _moveManager;
    private Shy_Manager_Tile _tileManager;
    private Camera _mainCamera;

    private int _currentTileIdx = 24;
    private bool _isFighting;

    private void Awake()
    {
        _tileTrmList = new List<Transform>();
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        _moveManager = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Move>();
        _tileManager = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Tile>();
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
        
    }

    private void Move(int idx)
    {
        if (idx < 0 || idx >= 49) return;

        if (CanMove())
        {
            transform.position = _tileManager.tileObjs[idx].transform.position;
            _currentTileIdx = idx;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _tileTrmList.Add(collision.gameObject.transform);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
