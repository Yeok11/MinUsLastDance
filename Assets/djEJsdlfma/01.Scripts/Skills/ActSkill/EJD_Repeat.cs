using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_Repeat : Shy_Skill
{
    private Shy_Manager_Tile usedTile;
    [SerializeField] private Shy_Tile used;

    private void Awake()
    {
        usedTile = FindObjectOfType<Shy_Manager_Tile>().GetComponent<Shy_Manager_Tile>();
    }

    private void Update()
    {
        if (usedTile.usedTiles.Count != 0)
            if (usedTile.usedTiles.Count > 1) usedTile.usedTiles.RemoveAt(0);
    }

    public override void ActSkill(int _skillLv)
    {
        used = usedTile.usedTiles[0];
        //사용된 타일 사용
    }
}
