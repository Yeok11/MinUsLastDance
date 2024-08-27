using System;
using System.Reflection;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    static public  Enemy _target { get; private set; } = null;

    static public Enemy SelectTarget(Enemy enemy)
    {
        Debug.Log(enemy.name);
        return _target = enemy;
    }

}
