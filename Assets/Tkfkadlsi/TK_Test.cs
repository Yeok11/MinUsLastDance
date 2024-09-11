using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TK_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Shy_Player player = FindObjectOfType<Shy_Player>();

        Debug.Log(GetComponent<TK_SkillConst>().GetValue(0, player));
    }
}
