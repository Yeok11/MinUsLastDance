using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ah_ButtonUI : MonoBehaviour
{
    public string GameMainScene;
    public void Quit()
    {
        Application.Quit();
    }
    public void StartButton()
    {
        SceneManager.LoadScene(GameMainScene);
    }
}
