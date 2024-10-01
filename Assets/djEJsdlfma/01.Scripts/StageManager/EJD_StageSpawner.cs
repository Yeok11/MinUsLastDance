using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EJD_StageSpawner : MonoBehaviour
{
    [SerializeField] private List<Image> tiles = new List<Image>();
    [SerializeField] private List<StageSO> map;
    [SerializeField] private Color enemyTileColor;

    private void Start()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            if (map[0].mapData[i] == 1)
            {
                tiles[i].color = enemyTileColor;
            }
        }
    }
}