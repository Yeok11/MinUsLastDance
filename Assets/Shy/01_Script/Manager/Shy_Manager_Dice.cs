using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shy_Manager_Dice : MonoBehaviour
{
    [Header("행동력")]
    public int actionPoint;
    public int ActionPoint
    {
        get => actionPoint;
        set => actionPoint = maxActionPoint < value ? maxActionPoint : value;
    }
    public int maxActionPoint;

    [Header("이동력")]
    public int movePoint = 0;

    [SerializeField, Header("텍스트")] private TextMeshProUGUI text_actionPoint;
    private Shy_Player player;

    private void Awake()
    {
        player = transform.parent.GetComponentInChildren<Shy_Player>();
        ActionPoint = maxActionPoint;
    }

    public void Update_PointSign()
    {
        text_actionPoint.SetText(ActionPoint + " / " + maxActionPoint);
    }

    private void Update()
    {
        Update_PointSign();
    }
}
