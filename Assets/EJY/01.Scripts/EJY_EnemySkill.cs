using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EJY_EnemySkill : MonoBehaviour
{
    public int life;
    public int tileNum;
    private Shy_Player player;

    public virtual void Use()
    {
    }
}
