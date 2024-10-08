using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_BuffSkill : TK_Skill
{
    [SerializeField] protected Shy_Stack buffStack;

    public override bool CanUseSkill(Shy_Player player)
    {
        return base.CanUseSkill(player);
    }

    public override void SkillLevelUp()
    {
        base.SkillLevelUp();
    }

    public override void UseSkill()
    {
        Shy_Player player = FindObjectOfType<Shy_Player>();
        player.stacks.Add(buffStack);
    }
}
