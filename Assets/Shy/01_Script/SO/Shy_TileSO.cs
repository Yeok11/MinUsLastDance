using UnityEngine;

public enum SKILLTHEMA
{
    NONE,
    FIGHT,
    HUNTING,
    MAGIC
}

[CreateAssetMenu(fileName = "Tile", menuName = "SO/Shy/TileSkill")]
public class Shy_TileSO : Shy_Obj
{
    public string tileName;
    public Shy_Skill effect;
    public Sprite image;
    [Range(1,3)]public int skillLevel;
    public SKILLTHEMA thema = SKILLTHEMA.NONE;
    [TextArea] public string valueFormula;


    public Shy_TileSO(Shy_TileSO _stSO)
    {
        tileName = _stSO.tileName;
        effect = _stSO.effect;
        image = _stSO.image;
        skillLevel = _stSO.skillLevel;
        thema = _stSO.thema;
        valueFormula = _stSO.valueFormula;
    }
}
