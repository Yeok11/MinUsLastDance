using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ahahau_PlayerClick : MonoBehaviour, IPointerClickHandler

{
    public Vector2 PlayerCurrentPos { get; set; }
    public void OnPointerClick(PointerEventData eventData)
    {
        Ahahau_GameManager.Instance.playerMoveOn = true;
        PlayerCurrentPos = new Vector2(transform.position.x, transform.position.y);
        Debug.Log("플레이어 클릭: " + PlayerCurrentPos);
    }

}
