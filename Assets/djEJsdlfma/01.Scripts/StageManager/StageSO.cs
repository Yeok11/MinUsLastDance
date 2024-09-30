using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/map")]
public class StageSO : ScriptableObject
{
    public List<int> mapData = new List<int>(49);
}
