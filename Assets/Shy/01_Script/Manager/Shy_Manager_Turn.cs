using EJY;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shy_Manager_Turn : MonoBehaviour
{
    public List<EJY_Enemy> enemys;
    public Shy_Player player;
    private Shy_Manager_Enemy manager_E;
    public List<InvolvedSkillData_SO> tileEventByEnemy;

    public void Start()
    {
        manager_E = transform.parent.GetComponentInChildren<Shy_Manager_Enemy>();
        //enemys = manager_E.SetEnemy(2);
        SetTurn();
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

    private void EnemyTurnStart()
    {
        ActionEnemyTileSkills();
    }
    

    public void SetTurn()
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
