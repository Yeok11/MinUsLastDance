using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shy_Manager_Enemy : MonoBehaviour
{
    [SerializeField] private List<EJY_Enemy> enemyPrefabs;
    [SerializeField] private List<EJY_Enemy> bossPrefabs;
    [SerializeField] private Transform[] enemyPos = { };

    public List<EJY_Enemy> SetEnemy(int _value = 1, bool _isBoss = false)
    {
        List<EJY_Enemy> enemys = new List<EJY_Enemy>();

        List<int> pos = new List<int>{ 0, 1, 2, 3};

        for (int i = 0; i < _value; i++)
        {
            int ePos = Random.Range(0, pos.Count);
            EJY_Enemy enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], enemyPos[pos[ePos]]);
            enemy.transform.position = enemy.transform.parent.position;
            pos.RemoveAt(ePos);
            enemys.Add(enemy);
        }
        
        return enemys;
    }
}
