using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EVENT_TYPE
{
    NONE,
    GET_CARD,
    UPGRADE_CARD,
    UPGRADE_CARD_RAND,
    DEL_CARD,
    DEL_CARD_RAND,
    GET_DICE,
    DEL_DICE,
    DEL_DICE_RAND,
    CHANGE_HEALTH,
    HEAL,
    DAMAGE,
}


[System.Serializable]
public class Shy_Event_Data
{
    public string mes;
    public EVENT_TYPE type;
    public List<Shy_Event_Card> data;
}
