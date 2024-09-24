using UnityEngine;

public enum SKILLTHEMA
{
    NONE,
    FIGHT,
    HUNTING,
    MAGIC
}

[CreateAssetMenu(fileName = "Tile", menuName = "SO/Shy/TileSkill")]
public class Shy_TileSO : ScriptableObject
{
    public string tileName;
    public Shy_Skill effect;
    public Sprite image;
    [Range(1,3)]public int skillLevel;
    public SKILLTHEMA thema = SKILLTHEMA.NONE;
    [TextArea] public string valueFormula;
}
