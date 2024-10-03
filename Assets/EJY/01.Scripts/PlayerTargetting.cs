using UnityEngine;

public class PlayerTargetting : MonoBehaviour
{
    static public  EJY_Enemy _target { get; private set; } = null;

    static public EJY_Enemy SelectTarget(EJY_Enemy enemy)
    {
        Debug.Log(enemy.name);
        return _target = enemy;
    }

}
