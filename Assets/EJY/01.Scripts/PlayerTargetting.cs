using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTargetting : MonoBehaviour
{
    static public  EJY_Enemy _target { get; private set; } = null;
    public static Image targetImg;

    static public EJY_Enemy SelectTarget(EJY_Enemy enemy)
    {
        targetImg.transform.parent = enemy.transform;
        targetImg.transform.position = enemy.transform.position;
        targetImg.transform.localScale = Vector3.one;

        return _target = enemy;
    }

    public static void AutoEnemySet()
    {
        List<EJY_Enemy> enemies = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().enemys;
        if(enemies.Count != 0)
        {
            PlayerTargetting.SelectTarget(enemies[0]);
        }
    }

}
