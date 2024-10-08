using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Ahahau_TileClick : MonoBehaviour, IPointerClickHandler
{
    public int _tileNum;
    public Ah_PlayerMove _playerMove;

    public void OnPointerClick(PointerEventData eventData)
    {
        _playerMove.PlayerMoveToInt(_tileNum);
        print("tileNum:" +  _tileNum);
    }
}
