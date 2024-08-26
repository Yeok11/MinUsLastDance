using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ahahau_GameManager : MonoBehaviour
{
    public static Ahahau_GameManager Instance;
    public bool playerMoveOn;
    public int playerTurn;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

}
