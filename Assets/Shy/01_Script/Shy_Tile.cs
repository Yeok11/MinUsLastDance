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
    internal bool alreadyUse = false;

    public void Setting()
    {
        UpdateImage();
        transform.GetChild(0).gameObject.SetActive(true);
        alreadyUse = false;
    }

    private void UpdateImage()
    {
        Image childImg = transform.GetChild(0).GetComponent<Image>();

        if (childImg.sprite != null)
            childImg.sprite = null;

        if (skillData != null)
            childImg.sprite = skillData.image;
    }

    public void SettingTile()
    {
        Debug.Log(gameObject.name + "타일 리셋");
        transform.GetChild(0).gameObject.SetActive(false);
        tileManager.usedTiles.Add(this);
        tileManager.tileSOList.Add(skillData);
        skillData = null;
        alreadyUse = true;
    }

    private void ActTile()
    {
        Debug.Log(gameObject.name + " 작동");
        if (alreadyUse)
            return;


        if(skillData != null)
        {
            skillData.effect.ActSkill();
        }
        
        SettingTile();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        tileManager.smd.DataUpdate(skillData);

    }
}
