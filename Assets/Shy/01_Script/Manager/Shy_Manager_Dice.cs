using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shy_Manager_Dice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text_actionPoint;

    public void Update_PointSign()
    {
        text_actionPoint.SetText(Shy_Manager.instance.ActionPoint + " / " + Shy_Manager.instance.maxActionPoint);
    }

    private void Update()
    {
        Update_PointSign();
    }
}
