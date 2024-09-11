using UnityEngine;

[CreateAssetMenu(fileName = "Tile", menuName = "SO/Shy/TileSkill")]
public class Shy_TileSO : ScriptableObject
{
    public string tileName;
    public Shy_Skill effect;
    public Sprite image;
}
