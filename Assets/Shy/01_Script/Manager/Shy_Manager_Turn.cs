using EJY;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shy_Manager_Turn : MonoBehaviour
{
    private Shy_Manager_Dice manager_D;
    private Shy_Manager_Enemy manager_E;

    public List<EJY_Enemy> enemys;
    public List<InvolvedSkillData_SO> tileEventByEnemy;

    [SerializeField] private Image targetIcon;

    private EJY_Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<EJY_Player>();

        manager_E = transform.parent.GetComponentInChildren<Shy_Manager_Enemy>();
        manager_E.smt = this;
        manager_D = transform.parent.GetComponentInChildren<Shy_Manager_Dice>();
    }

    public void Start()
    {
        enemys = manager_E.SetEnemy(2); //에너미 소환

        SetEnemyOrder();
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForEndOfFrame();
        Init();
    }

    private void Init()
    {
        manager_D.AllDiceRoll();
        _player.Init();
        _player._isFighting = true;
        PlayerTargetting.targetImg = Instantiate(targetIcon);

        PlayerTargetting.AutoEnemySet();

        PlayerTurnStart();
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

    private void PlayerTurnStart()
    {
        Debug.Log("플레이어 턴 시작");
    }

    public void PlayerTurnEnd()
    {
        Debug.Log("플레이어 턴 종료");


        //타일 초기화
        _player._tileManager.UsedTileUpdate();
        
        
        //에너미 턴 시작
        StartCoroutine(EnemyTurnStart());
    }

    private IEnumerator EnemyTurnStart()
    {
        yield return new WaitForSeconds(3f);

        Debug.Log("에너미 턴 시작");
        ActionEnemyTileSkills();

        yield return new WaitForSeconds(5f);

        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].EnemyAction();
        }

        yield return new WaitForSeconds(5f);

        EnemyTurnEnd();
    }

    private void EnemyTurnEnd()
    {
        Debug.Log("에너미 턴 종료");
    }
    

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
    }
}
