using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class Ah_TileClick : MonoBehaviour, IPointerClickHandler
{
    public int tileNum;

    public void OnPointerClick(PointerEventData eventData)
    {
        a_PlayerMove.instance.PlayerMoveToInt(tileNum);
        print("tileNum:" +  tileNum);
    }
}
