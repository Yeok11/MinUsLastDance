using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ahahau_GameManager : MonoBehaviour
{
    public static Ahahau_GameManager Instance;
    public bool playerClick;
    public int playerTurn;
    public bool tileClick;
    public int tileIndex;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

}
