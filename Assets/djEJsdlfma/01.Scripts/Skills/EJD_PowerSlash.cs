using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_PowerSlash : TK_AttackSkill
{
    public override void UseSkill()
    {
        foreach (var e in Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Tile>().tileObjs)
        {
            //Ÿ�� if������ ����ؼ� ������
        }
    }
}
