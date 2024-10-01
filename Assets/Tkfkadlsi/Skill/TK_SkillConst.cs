using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public enum COUNT_STACK_TYPE
{
    NONE,
    MANA,
    HUNT
}


[Serializable]
public class TK_SkillConst
{
    public COUNT_STACK_TYPE UseStack = COUNT_STACK_TYPE.NONE;
    [Header("N(player)를 사용하면 스택 값을 가져올 수 있다.")]public List<string> ValueFormula = new List<string>(3);

    private DataTable dt = new DataTable();

    private float N()
    {
        Shy_Player p = GameObject.FindObjectOfType<Shy_Player>();

        for (int i = 0; i < p.stacks.Count; i++)
        {
            if (p.stacks[i].stackName.Contains(UseStack.ToString()))
            {
                p.stacks[i].TryGetComponent(out Shy_Stack_Cnt cnt);
                return cnt.count;
            }
        }

        //Debug.LogError("식 잘못 썼거나 존재하지 않는다.");
        return 0;
    }

    public float GetValue(int skillLevel)
    {
        string formula = ValueFormula[skillLevel - 1];

        formula = formula.Replace("N(player)", N().ToString());
        formula = formula.Replace("f", "");
        Debug.Log(formula);

        return float.Parse(dt.Compute(formula, "").ToString());
    }
}

