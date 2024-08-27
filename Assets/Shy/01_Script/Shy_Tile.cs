using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shy_Tile : MonoBehaviour, IPointerClickHandler
{
    public Shy_TileSO skillData;
    internal Shy_Manager_Tile tileManager;

    public void UpdateImage()
    {
        Image childImg = transform.GetChild(0).GetComponent<Image>();

        if (childImg.sprite != null)
            childImg.sprite = null;

        if (skillData != null)
            childImg.sprite = skillData.image;
    }

    public void UsedTile()
    {
        Debug.Log(gameObject.name + "Ÿ�� ����");
        tileManager.TileSetting(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (skillData == null)
        {
            Debug.Log("skill�� �����ϴ�.");
            return;
        }
        //Debug.Log(skillData.tileName);
        skillData.effect.ActSkill();
        UsedTile();
    }
}