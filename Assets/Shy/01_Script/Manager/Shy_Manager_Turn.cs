using EJY;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shy_Manager_Turn : MonoBehaviour
{
    #region ������(�� ����)
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
        StartCoroutine(Shy_SceneMove.instance.OpenScene(true)); //ȭ�� ��Ӱ�
        yield return new WaitForEndOfFrame();
        
        //stage
        sss.ShowStage();
        Init();

        yield return new WaitForSeconds(5);
        StartCoroutine(Shy_SceneMove.instance.OpenScene()); //��� ����
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

        #region ���� �ʱ�ȭ
        int cnt = player.stackPos.childCount;
        for (int i = 0; i < cnt; i++)
            Destroy(player.stackPos.GetChild(0).gameObject);
        player.stacks.Clear();
        #endregion

        #region ��ġ + ����Ʈ �ʱ�ȭ
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
        Debug.LogError("�÷��̾� �� ����");
        manager_Move.actionPoint = 10;
        manager_Move.Update_PointSign();
    }

    public void PlayerTurnEnd()
    {
        Debug.LogError("�÷��̾� �� ����");
        endBt.gameObject.SetActive(false);
        manager_Move.movePoint = 0;
        manager_Move.Update_PointSign();

        //Ÿ�� �ʱ�ȭ
        _player._tileManager.UsedTileUpdate();

        //�� ���� �ʱ�ȭ
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].HealthCompo._currentBarrier = 0;
            enemys[i].HealthCompo.GetBarrier(0);
        }

        //���ʹ� �� ����
        StartCoroutine(EnemyTurnStart());
    }

    private IEnumerator EnemyTurnStart()
    {
        yield return new WaitForSeconds(2.2f);

        Debug.Log("���ʹ� �� ����");
        Debug.LogError("���ʹ� �� ����");
        ActionEnemyTileSkills();

        //���ʹ� �ൿ
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
        Debug.LogError("���ʹ� �� ����");
        
        //���� �ൿ ǥ��
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].SetNextSkill();
        }

        //�÷��̾� ���� �ʱ�ȭ
        player.HealthCompo._currentBarrier = 0;
        player.HealthCompo.GetBarrier(0);

        PlayerTurnStart();
    }
    #endregion



    public void UseEvent()
    {
        manager_Event.ResultEvent();
    }

    //�� ���� ����
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
