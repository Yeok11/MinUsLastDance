using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class Ahahau_TileClick : MonoBehaviour, IPointerClickHandler
{
    private string tileName;
    private string tileNum;
    public void OnPointerClick(PointerEventData eventData)
    {
        tileName = gameObject.name;
        tileNum = Regex.Replace(tileName, @"\D", "");
        Ahahau_GameManager.Instance.tileIndex = int.Parse(tileNum);
        Ahahau_GameManager.Instance.tileIndex--;

        Ahahau_GameManager.Instance.tileClick = true;
    }
}
