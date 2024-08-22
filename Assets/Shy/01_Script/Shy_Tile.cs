using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shy_Tile : MonoBehaviour, IPointerClickHandler
{
    public Shy_TileSO skillData;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (skillData == null)
        {
            Debug.Log("skill이 없습니다.");
            return;
        }
        Debug.Log(skillData.tileName);
        skillData.effect.ActSkill();
    }
}
