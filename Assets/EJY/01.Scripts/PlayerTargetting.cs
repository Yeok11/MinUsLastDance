using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTargetting : MonoBehaviour
{
    static public  EJY_Enemy _target { get; private set; } = null;
    public static Image targetImg;
    private static Shy_Manager_Turn smt;

    static public EJY_Enemy SelectTarget(EJY_Enemy enemy)
    {
        targetImg.transform.parent = enemy.transform;
        targetImg.transform.position = enemy.transform.position;
        targetImg.transform.localScale = Vector3.one;

        return _target = enemy;
    }

    public static void AutoEnemySet()
    {
        if(smt == null)
        {
            smt = Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>();
        }
        List<EJY_Enemy> enemies = smt.enemys;

        PlayerTargetting.SelectTarget(enemies[0]);
    }

}
