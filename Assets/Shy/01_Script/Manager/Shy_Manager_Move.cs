using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shy_Manager_Move : MonoBehaviour
{
    [Header("행동력")]
    public int actionPoint;
    public int ActionPoint
    {
        get => actionPoint;
        set
        {
            actionPoint = maxActionPoint < value ? maxActionPoint : value;
            actionPoint = value >= 0 ? value : 0;
            Update_PointSign();
        }
    }
    public int maxActionPoint;

    [Header("이동력")]
    public int movePoint = 0;

    [Header("텍스트")]
    [SerializeField] private TextMeshProUGUI text_actionPoint;
    [SerializeField] private TextMeshProUGUI text_movePoint;
    private EJY_Player player;


    private void Awake()
    {
        player = FindObjectOfType<EJY_Player>();
        player._moveManager = this;
        ActionPoint = maxActionPoint;
    }

    public void Update_PointSign()
    {
        text_actionPoint.SetText(ActionPoint + " / " + maxActionPoint);
        text_movePoint.SetText("MP : " + movePoint);
    }

    public void Move()
    {
        movePoint -= 1;
        Update_PointSign();

        if (movePoint == 0)
        {
            player._tileManager.tileObjs[player._currentTileIdx].ActTile();
            player._moved.Clear();

            foreach (GameObject item in player.mark)
            {
                Destroy(item);
            }

            player.mark.Clear();
        }
    }
}
