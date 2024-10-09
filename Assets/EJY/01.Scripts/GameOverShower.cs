using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverShower : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;

    public void ShowGameOverUI()
    {
        _gameOverUI.SetActive(true);
    }
}
