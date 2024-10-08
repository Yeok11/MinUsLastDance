using EJY;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shy_Tile : MonoBehaviour, IPointerClickHandler
{
    public Shy_TileSO skillData;
    public InvolvedSkillData_SO enemySkillData;
    internal Shy_Manager_Tile tileManager;

    public void Setting()
    {
        Image childImg = transform.GetChild(0).GetComponent<Image>();

        childImg.sprite = null;

        if (skillData != null)
        {
            childImg.gameObject.SetActive(true);
            childImg.sprite = skillData.image;
        }
            
    }

    public void ResetTile()
    {
        Debug.Log(gameObject.name + "타일 리셋");
        transform.GetChild(0).gameObject.SetActive(false);
        tileManager.usedTiles.Add(this);
        tileManager.tileSOList.Add(skillData);
        skillData = null;
    }

    public void ActTile()
    {
        Debug.Log(gameObject.name + " 작동");

        if(skillData != null)
        {
            skillData.effect.ActSkill();
        }

        tileManager.smd.DataUpdate(null);
        ResetTile();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        //if (skillData != null)
        //    skillData.effect.ActSkill();
        tileManager.smd.DataUpdate(skillData);
    }
}
