using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shy_Event_Select : MonoBehaviour
{
    public int curSelectInt = 99;

    [SerializeField] private GameObject selectPanel;
    [SerializeField] private Shy_Event_SelectItem itemTool;
    [SerializeField] private Sprite dicePrefab;
    private Shy_Deck deck;
    private bool diceChange;

    [Header("Item_Info")]
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemExplain;
    [SerializeField] private List<Image> ranks;
    [SerializeField] private Color levelColor_O;
    [SerializeField] private Color levelColor_X;

    public void Init(Shy_Deck _sDeck, bool _isDice)
    {
        selectPanel.SetActive(true);
        Transform board = selectPanel.transform.Find("Board");

        deck = _sDeck;
        diceChange = _isDice;

        deck.diceDeck.Sort();
        deck.tileDeck.Sort();

        for (int i = 0; i < (diceChange ? deck.diceDeck.Count : deck.tileDeck.Count); i++)
        {
            Shy_Event_SelectItem item = Instantiate(itemTool);
            item.transform.parent = board;
            item.transform.localScale = Vector3.one;
            item.ses = this;
            item.GetComponent<Image>().sprite = diceChange ? dicePrefab : deck.tileDeck[i].image;
        }
    }

    public void ShowData(int _curInt)
    {
        curSelectInt = _curInt;
        itemName.text = /*diceChange ? deck.diceDeck[_curInt]. :*/ deck.tileDeck[_curInt].tileName;
        itemExplain.text = deck.tileDeck[_curInt].valueFormula;
        for (int i = 1; i <= 3; i++)
        {
            ranks[i - 1].color = deck.tileDeck[_curInt].skillLevel >= i ? levelColor_O : levelColor_X;
        }
    }

    public void SelectItem()
    {
        if (curSelectInt == 99) return;

        selectPanel.SetActive(false);
        Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Event>().SelectEvent(curSelectInt);
    }
}
