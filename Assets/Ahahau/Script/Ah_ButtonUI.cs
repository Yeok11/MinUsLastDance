using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ah_ButtonUI : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void Setting()
    {

    }

    public void StartButton(string GameMainScene)
    {
        SceneManager.LoadScene(GameMainScene);
    }
}
