using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ahahau_Move : MonoBehaviour
{
    private Ahahau_Battle _battle;
    [SerializeField] private List<Image> boredImages = new List<Image>();
    private int _currentIndex = 24;
    private float _x;
    private float _y;
    private bool _colorChange;
    private Ahahau_PlayerClick _playerClick;
    private int _intX;
    private int _intY;
    private int _nextIndex;
    private void Awake()
    {
        _playerClick = GetComponent<Ahahau_PlayerClick>();
        _battle = GetComponent<Ahahau_Battle>();
        _nextIndex = _currentIndex;
    }

    private void Update()
    {
        _x = Input.GetAxisRaw("Horizontal");
        _y = Input.GetAxisRaw("Vertical");

        if (Ahahau_GameManager.Instance.playerMoveOn)
        {
            Ahahau_GameManager.Instance.playerMoveOn = false;
            print("클릭됌");
            if (_battle.MovePoint > 0)
            {
                print("movepoint 있음");
                ColorChange();
            }
        }
        if (_colorChange)
        {
            if (_x != 0 || _y != 0)
            {
                _intX = Mathf.FloorToInt(_x);
                _intY = Mathf.FloorToInt(_y);
                _nextIndex += _intX -= (_intY * 7);
                if (_nextIndex >= 0 && _nextIndex <= 48 && boredImages[_nextIndex].color == Color.green)
                {
                    Debug.Log("_nextIndex:" + _nextIndex);
                    _currentIndex = _nextIndex;
                    Movement();
                    _colorChange = false;
                }
                else
                {
                    _nextIndex = _currentIndex;
                }
            }
        }
    }

    private void Movement()
    {
        transform.position = boredImages[_currentIndex].transform.position;
        _battle.MovePoint--;
        ClearColor();
    }
    private void ColorChange()
    {
        boredImages[_currentIndex].color = Color.green;

        if (_currentIndex % 7 != 0)
            boredImages[_currentIndex - 1].color = Color.green;

        if ((_currentIndex + 1) % 7 != 0)
            boredImages[_currentIndex + 1].color = Color.green;

        if (!(_currentIndex <= 6))
            boredImages[_currentIndex - 7].color = Color.green;

        if (!(_currentIndex >= 42))
            boredImages[_currentIndex + 7].color = Color.green;
        _colorChange = true;
    }
    private void ClearColor()
    {
        for (int i = 0; i < boredImages.Count; i++)
        {
            boredImages[i].color = Color.white;
        }
    }

}
