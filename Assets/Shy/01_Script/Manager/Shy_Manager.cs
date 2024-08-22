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


    public int actionPoint;
    public int ActionPoint
    {
        get => actionPoint;
        set => actionPoint = maxActionPoint < value ? maxActionPoint : value;
    }
    public int maxActionPoint;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActionPoint += 1;
        }
    }
}
