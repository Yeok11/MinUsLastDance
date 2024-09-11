using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public enum COUNT_STACK_TYPE
{
    MANA,
    HUNT
}


[Serializable]
public class TK_SkillConst
{
    public COUNT_STACK_TYPE UseStack;
    public List<string> ValueFormula = new List<string>();

    private DataTable dt = new DataTable();

    private float N(Shy_Player player)
    {
        foreach (Shy_Stack stack in player.stacks)
        {
            if(stack.TryGetComponent(out Shy_Stack_Cnt st))
            {
                if(st.stackName == UseStack.ToString())
                    return st.count;
            }
        }

        Debug.LogError("식 잘못 썼다 빠가야로.");
        return 0;
    }

    public float GetValue(int skillLevel, Shy_Player player)
    {
        string formula = ValueFormula[skillLevel];

        Debug.Log(N(player));
        formula = formula.Replace("N(player)", N(player).ToString());
        formula = formula.Replace("f", "");
        Debug.Log(formula);

        return float.Parse(dt.Compute(formula, "").ToString());
    }
}

