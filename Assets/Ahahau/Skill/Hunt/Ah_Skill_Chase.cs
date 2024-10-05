using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ah_Skill_Chase : Shy_Skill
{
    private Shy_Player player;
    public override void ActSkill(int _skillLv = 1)
    {
        if (player == null) player = FindObjectOfType<Shy_Player>();
        int value = 2 * Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().enemys.Count;
        player.SetStack(COUNT_STACK_TYPE.HUNT, value);
    }
}
