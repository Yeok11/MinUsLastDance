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

    [SerializeField] private int nowTextNum = 0;

    private void Start()
    {
        nowTextNum = 0;
        StartCoroutine(UpdateText());
    }

    public IEnumerator UpdateText()
    {
        if (messages[nowTextNum].sprite != null)
            imagePos.sprite = messages[nowTextNum].sprite;

        textPos.text = "";

        for (int i = 0; i < messages[nowTextNum].contents.Length; i++)
        {
            textPos.text += messages[nowTextNum].contents[i];
            yield return new WaitForSeconds(messages[nowTextNum].speed);
        }
    }
}
