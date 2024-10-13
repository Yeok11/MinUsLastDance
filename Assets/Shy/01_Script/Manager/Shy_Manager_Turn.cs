using EJY;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shy_Manager_Turn : MonoBehaviour
{
    #region 변수들(좀 역함)
    private Shy_Manager_Dice manager_D;
    private Shy_Manager_Enemy manager_E;
    private Shy_Manager_Move manager_Move;
    private Shy_Manager_Event manager_Event;
    [SerializeField] private Shy_Stage_Shower sss;

    public List<EJY_Enemy> enemys;
    public List<InvolvedSkillData_SO> tileEventByEnemy;

    [SerializeField] private Image targetIcon;

    private EJY_Player _player;
    private Shy_Player player;
    [SerializeField] private Button endBt;

    internal int[] stage = { 1,1,2,2,3,4,4 };
    #endregion


    private void Awake()
    {
        _player = FindObjectOfType<EJY_Player>();
        player = _player.GetComponent<Shy_Player>();

        manager_E = transform.parent.GetComponentInChildren<Shy_Manager_Enemy>();
        manager_E.smt = this;
        manager_D = transform.parent.GetComponentInChildren<Shy_Manager_Dice>();
        manager_Move = manager_D.GetComponent<Shy_Manager_Move>();
        manager_Event = transform.parent.GetComponentInChildren<Shy_Manager_Event>();
    }
    public void Start()
    {
        NewGame();
    }


    public void NewGame()
    {
        Debug.Log("Game Init");
        PlayerTargetting.targetImg = Instantiate(targetIcon);

        if (sss.stageNum < stage.Length)
            enemys = manager_E.SetEnemy(stage[sss.stageNum]);
        else
            SceneManager.LoadScene("EJY_End");

        SetEnemyOrder();
        StartCoroutine(StartAnime());
    }

    private IEnumerator StartAnime()
    {
        StartCoroutine(Shy_SceneMove.instance.OpenScene(true)); //화면 어둡게
        yield return new WaitForEndOfFrame();
        
        //stage
        sss.ShowStage();
        Init();

        yield return new WaitForSeconds(5);
        StartCoroutine(Shy_SceneMove.instance.OpenScene()); //어둠 해제
    }

    public int EnemyDestroy(EJY_Enemy _enemy)
    {
        enemys.Remove(_enemy);

        return enemys.Count;
    }

    private void Init()
    {
        manager_D.AllDiceRoll();

        PlayerTargetting.AutoEnemySet();

        #region 스택 초기화
        int cnt = player.stackPos.childCount;
        for (int i = 0; i < cnt; i++)
            Destroy(player.stackPos.GetChild(0).gameObject);
        player.stacks.Clear();
        #endregion

        #region 위치 + 포인트 초기화
        _player.Init();
        _player.Move(24, false, true);
        manager_Move.movePoint = 0;
        manager_Move.actionPoint = 0;
        #endregion

        EnemyTurnEnd();
    }

    private void ActionEnemyTileSkills()
    {
        for (int i = 0; i < tileEventByEnemy.Count;)
        {
            if (tileEventByEnemy[i].Use())
                tileEventByEnemy.RemoveAt(i);
            else
                ++i;
        }
    }


    #region Main System
    private void PlayerTurnStart()
    {
        endBt.gameObject.SetActive(true);
        Debug.LogError("플레이어 턴 시작");
        manager_Move.actionPoint = 10;
        manager_Move.Update_PointSign();
    }

    public void PlayerTurnEnd()
    {
        Debug.LogError("플레이어 턴 종료");
        endBt.gameObject.SetActive(false);
        manager_Move.movePoint = 0;
        manager_Move.Update_PointSign();

        //타일 초기화
        _player._tileManager.UsedTileUpdate();

        //적 방어력 초기화
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].HealthCompo._currentBarrier = 0;
            enemys[i].HealthCompo.GetBarrier(0);
        }

        //에너미 턴 시작
        StartCoroutine(EnemyTurnStart());
    }

    private IEnumerator EnemyTurnStart()
    {
        yield return new WaitForSeconds(2.2f);

        Debug.Log("에너미 턴 시작");
        Debug.LogError("에너미 턴 시작");
        ActionEnemyTileSkills();

        //에너미 행동
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].EnemyAction();
            yield return new WaitForSeconds(1.2f);
        }

        yield return new WaitForSeconds(3f);

        EnemyTurnEnd();
    }

    private void EnemyTurnEnd()
    {
        Debug.LogError("에너미 턴 종료");
        
        //다음 행동 표시
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].SetNextSkill();
        }

        //플레이어 방어력 초기화
        player.HealthCompo._currentBarrier = 0;
        player.HealthCompo.GetBarrier(0);

        PlayerTurnStart();
    }
    #endregion



    public void UseEvent()
    {
        manager_Event.ResultEvent();
    }

    //적 순서 지정
    public void SetEnemyOrder()
    {
        for (int i = 0; i < enemys.Count - 1; i++)
        {
            if(enemys[i].stat._speed < enemys[i+1].stat._speed)
            {
                EJY_Enemy temp = enemys[i];
                enemys[i] = enemys[i + 1];
                enemys[i + 1] = temp;

                i = 0;
            }
        }

        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].transform.Find("OrderTxt").GetComponent<TextMeshProUGUI>().text = i.ToString();
        }
    }
}
