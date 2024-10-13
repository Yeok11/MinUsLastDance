using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

enum STAGE_TYPE
{
    BATTLE,
    EVENT,
    BOSS
}

public class Shy_Stage_Shower : MonoBehaviour
{
    [Header("Color")]
    [SerializeField] private Color normalColor;
    [SerializeField] private Color clearColor;

    [Header("Player")]
    [SerializeField] private GameObject playerMark;
    [Range(0, 7)] public int stageNum = 0;

    [Header("Icon")]
    [SerializeField] private Sprite icon_battle;
    [SerializeField] private Sprite icon_event;

    [Header("other")]
    [SerializeField] private Transform listParent;

    [SerializeField] internal STAGE_TYPE[] stages = { 
        STAGE_TYPE.BATTLE,  //0
        STAGE_TYPE.BATTLE, 
        STAGE_TYPE.BATTLE, 
        STAGE_TYPE.BATTLE, 
        STAGE_TYPE.BATTLE,
        STAGE_TYPE.BATTLE,
        STAGE_TYPE.BOSS     //6
    };

    private void Awake()
    {
        playerMark.transform.localPosition = new Vector2(-510, 45);
        playerMark.SetActive(false);
        InitStage();
    }

    public void InitStage()
    {
        int eventCnt = Random.Range(0,2) + 2;

        List<int> eventStageNum = new List<int>(){ 1, 2, 3, 4, 5 };

        //for (int i = 0; i < 2; i++)
        //{
        //    int rand = eventStageNum[Random.Range(0, eventStageNum.Count)];
        //    stages[rand] = STAGE_TYPE.EVENT;
        //    listParent.GetChild(rand).GetChild(0).GetComponent<Image>().sprite = icon_event;
        //    eventStageNum.Remove(rand);
        //}
    }

    public void ShowStage()
    {
        playerMark.SetActive(false);
        listParent.position = new Vector2(0, 800);

        listParent.DOMoveY(0, 1.7f).OnComplete(()=>listParent.DOMoveY(0, 1.2f).OnComplete(()=>
        {
            StartCoroutine(UpdateMark());
        }));
    }

    public IEnumerator UpdateMark()
    {
        playerMark.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        Debug.Log(stageNum);

        Sequence seq = DOTween.Sequence();

        seq.Append(playerMark.transform.DOJump(
            new Vector2(listParent.transform.GetChild(stageNum).position.x, 
            playerMark.transform.position.y), 1, 1, 0.4f));
        seq.Append(transform.DOMove(transform.position, 0.8f)).OnComplete(()=>
        {
            stageNum++;
            playerMark.SetActive(false);
            listParent.position = new Vector2(0, 800);
            Debug.Log(stageNum);
        });
        

    }
}
