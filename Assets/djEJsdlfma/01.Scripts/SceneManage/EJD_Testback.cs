using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EJD_Testback : MonoBehaviour
{
    public void BackBoard()
    {
        SceneManager.LoadScene("Board");
    }

    public void TestTellpo()
    {
        SceneManager.LoadScene("Battle");
    }
}
