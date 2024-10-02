using EJY;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shy_Manager_Turn : MonoBehaviour
{
    private Shy_Manager_Dice manager_D;
    private Shy_Manager_Enemy manager_E;

    public List<EJY_Enemy> enemys;
    public List<InvolvedSkillData_SO> tileEventByEnemy;

    private EJY_Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<EJY_Player>();
    }

    public void Start()
    {
        manager_E = transform.parent.GetComponentInChildren<Shy_Manager_Enemy>();
        manager_D = transform.parent.GetComponentInChildren<Shy_Manager_Dice>();
        //enemys = manager_E.SetEnemy(4); //���ʹ� ��ȯ
        SetEnemyOrder();
        PlayerTurnStart();
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
        _player._isFighting = true;
        _player.Init();
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
        Debug.Log("�÷��̾� �� ����");
    }

    public void PlayerTurnEnd()
    {
        Debug.Log("�÷��̾� �� ����");
    }

    private IEnumerator EnemyTurnStart()
    {
        Debug.Log("���ʹ� �� ����");
        ActionEnemyTileSkills();

        yield return new WaitForSeconds(5f);

        EnemyTurnEnd();
    }

    private void EnemyTurnEnd()
    {
        Debug.Log("���ʹ� �� ����");
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
