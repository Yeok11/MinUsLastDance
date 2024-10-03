using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Ah_Skill_Aiming : Shy_Skill
{
    [SerializeField]private Shy_Player player;
    public override void ActSkill(int _skillLv = 1)
    {
        foreach (var e in Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Tile>().tileObjs)
        {
            calculate.GetValue(_skillLv);
        }
    }

}
