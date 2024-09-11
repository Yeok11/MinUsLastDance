using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STACK_TYPE
{
    HUNT = 0,
    MANA,
    END
}

[System.Serializable]
public class Shy_Stack
{
    public string stackName = "";
    public int cnt = 0;
    public STACK_TYPE type;
    public GameObject obj;
}
