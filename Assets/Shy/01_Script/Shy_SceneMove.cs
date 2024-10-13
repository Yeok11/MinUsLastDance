using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shy_SceneMove : MonoBehaviour
{
    [SerializeField] internal Volume volume;
    [SerializeField] internal Image blackEffect;
    public static Shy_SceneMove instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public IEnumerator CloseScene(string _moveScene)
    {
        blackEffect.gameObject.SetActive(true);
        volume.gameObject.SetActive(true);
        blackEffect.color = new Color(Color.black.r, Color.black.g, Color.black.b, 0);
        volume.weight = 0;

        while (volume.weight < 1)
        {
            yield return new WaitForSeconds(0.1f);
            volume.weight += 0.1f;
        }

        while (blackEffect.color.a < 1)
        {
            yield return new WaitForSeconds(0.1f);
            blackEffect.color += new Color(0, 0, 0, 0.1f);
        }

        SceneManager.LoadScene(_moveScene);
    }

    public IEnumerator OpenScene(bool isNotAnime = false)
    {
        blackEffect.gameObject.SetActive(true);
        volume.gameObject.SetActive(true);
        blackEffect.color = new Color(Color.black.r, Color.black.g, Color.black.b, 1);

        volume.weight = 1;

        if (!isNotAnime)
        {
            while (blackEffect.color.a > 0)
            {
                yield return new WaitForSeconds(0.15f);
                blackEffect.color -= new Color(0, 0, 0, 0.1f);
            }

            while (volume.weight > 0)
            {
                yield return new WaitForSeconds(0.08f);
                volume.weight -= 0.1f;
            }

            blackEffect.gameObject.SetActive(false);
            volume.gameObject.SetActive(false);
        }
    }
}
