using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ahahau_PlayerClick : MonoBehaviour, IPointerClickHandler

{
    public Vector2 PlayerCurrentPos { get; set; }
    public void OnPointerClick(PointerEventData eventData)
    {
        Ahahau_GameManager.Instance.playerClick = true;
        PlayerCurrentPos = new Vector2(transform.position.x, transform.position.y);
    }

}
