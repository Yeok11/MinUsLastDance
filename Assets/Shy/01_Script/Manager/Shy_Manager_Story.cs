using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shy_Manager_Story : MonoBehaviour
{
    [SerializeField] private List<Shy_Message> messages;
    [SerializeField] private Image imagePos;
    [SerializeField] private TextMeshProUGUI textPos;
    private TextMeshProUGUI textShadow;

    [SerializeField] private int nowTextNum = 0;

    private void Start()
    {
        textShadow = textPos.transform.parent.GetComponent<TextMeshProUGUI>();
        nowTextNum = 0;
        textPos.text = "";
        textShadow.text = "";
        StartCoroutine(Init());
    }

    private bool canSpacebar = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StopAllCoroutines();
            StartCoroutine(Shy_SceneMove.instance.CloseScene("Shy_Main"));
        }

        if (canSpacebar && Input.GetKeyDown(KeyCode.Space))
        {
            if (nowTextNum >= messages.Count)
                StartCoroutine(Shy_SceneMove.instance.CloseScene("Shy_Main"));
            else
                StartCoroutine(UpdateText());
        }
    }

    private IEnumerator Init()
    {
        StartCoroutine(Shy_SceneMove.instance.OpenScene());
        yield return new WaitForSeconds(2.4f);
        StartCoroutine(UpdateText());
    }

    public IEnumerator UpdateText()
    {
        canSpacebar = false;

        if (messages[nowTextNum].sprite != null)
            imagePos.sprite = messages[nowTextNum].sprite;

        textPos.text = "";
        textShadow.text = "";

        for (int i = 0; i < messages[nowTextNum].contents.Length; i++)
        {
            textPos.text += messages[nowTextNum].contents[i];
            textShadow.text = textPos.text;
            yield return new WaitForSeconds(messages[nowTextNum].speed);
        }

        nowTextNum++;

        

        canSpacebar = true;
    }
}
