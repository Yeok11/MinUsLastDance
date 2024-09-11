using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shy_Manager_Dice : MonoBehaviour
{
    [Header("�ൿ��")]
    public int actionPoint;
    public int ActionPoint
    {
        get => actionPoint;
        set => actionPoint = maxActionPoint < value ? maxActionPoint : value;
    }
    public int maxActionPoint;

    [Header("�̵���")]
    public int movePoint = 0;

    [Header("�ؽ�Ʈ")]
    [SerializeField] private TextMeshProUGUI text_actionPoint;
    [SerializeField] private TextMeshProUGUI text_movePoint;
    private Shy_Player player;

    private void Awake()
    {
        player = transform.parent.GetComponentInChildren<Shy_Player>();
        ActionPoint = maxActionPoint;
    }

    public void Update_PointSign()
    {
        text_actionPoint.SetText(ActionPoint + " / " + maxActionPoint);
        text_movePoint.SetText("MP : " + movePoint);
    }

    private void Update()
    {
        Update_PointSign();
    }
}
