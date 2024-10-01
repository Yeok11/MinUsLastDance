using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(menuName = "SO/Selector")]
public class Shy_Event_Selector : ScriptableObject
{
    public string titleMes;
    [TextArea()]public string contatnsMes;
    public int per;
    public List<Shy_Event_Data> selectList;
}
