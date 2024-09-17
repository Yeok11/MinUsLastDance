using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GetPosition")]
public class EJD_PlayerPositionSO : ScriptableObject
{
    public float xPos = 0;
    public float yPos = 0;

    public bool isOut = false;
    public bool firstMove = true;
}
