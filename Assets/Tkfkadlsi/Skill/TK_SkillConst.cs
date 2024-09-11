using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[Serializable]
public class TK_SkillConst
{
    public STACK_TYPE UseStack;
    public List<string> ValueFormula = new List<string>();

    private DataTable dt = new DataTable();

    private float N(Shy_Player player)
    {
        foreach(Shy_Stack stack in player.stacks)
        {
            if (stack.type == UseStack)
            {
                return stack.cnt;
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
