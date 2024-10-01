using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shy_Manager_DataMes : MonoBehaviour
{
    [SerializeField] private GameObject dataParants;
    private TextMeshProUGUI title;
    private Image icon;
    private TextMeshProUGUI contants;

    private void Start()
    {
        title = dataParants.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        icon = dataParants.GetComponentInChildren<Image>();
        contants = dataParants.transform.Find("Contants").GetComponent<TextMeshProUGUI>();
        dataParants.SetActive(false);
    }


    public void DataUpdate(Shy_TileSO _so)
    {
        if(_so == null)
        {
            dataParants.SetActive(false);
            return;
        }

        dataParants.SetActive(true);
        title.text = _so.tileName;
        icon.sprite = _so.image;
        string explain = _so.valueFormula;
        if(explain.Contains("N"))
        {
            explain = explain.Replace("N", _so.effect.calculate.GetValue(_so.skillLevel).ToString());
        }
        contants.text = explain;
    }
}
