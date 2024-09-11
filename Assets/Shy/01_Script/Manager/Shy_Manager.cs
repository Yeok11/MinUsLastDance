using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shy_Manager : MonoBehaviour
{
    public static Shy_Manager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
}
