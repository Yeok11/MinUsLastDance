using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStack : MonoBehaviour
{
    [SerializeField] private Shy_Stack_Effect test1;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            test1.IsDestroy();
        }
    }
}
