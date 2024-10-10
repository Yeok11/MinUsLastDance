using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shy_Event_Select : MonoBehaviour
{
    public int curSelectInt = 99;

    [SerializeField] private GameObject inven;
    [SerializeField] private Transform listParent;
    [SerializeField] private Shy_Event_SelectItem itemTool;
    [SerializeField] private Sprite dicePrefab;
    [SerializeField] private GameObject blackPanel;

    private Shy_Deck deck;
    private bool diceChange;

    [Header("Item_Info")]
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemExplain;
    [SerializeField] private List<Image> ranks;
    [SerializeField] private Color levelColor_O;
    [SerializeField] private Color levelColor_X;

    private void TileDeckSort()
    {
        int charNum = 0;
        for (int i = 0; i < deck.tileDeck.Count - 1;)
        {
            if (deck.tileDeck[i].tileName[charNum] == deck.tileDeck[i + 1].tileName[charNum])
            {
                if (charNum + 1 == deck.tileDeck[i].tileName.Length || charNum + 1 == deck.tileDeck[i+1].tileName.Length)
                {
                    ++i;
                    charNum = 0;
                }
                else
                    ++charNum;
                continue;
            }
            else
            {
                if(deck.tileDeck[i].tileName[charNum] > deck.tileDeck[i + 1].tileName[charNum])
                {
                    Shy_TileSO so = deck.tileDeck[i];
                    deck.tileDeck[i] = deck.tileDeck[i + 1];
                    deck.tileDeck[i + 1] = so;
                    i = 0;
                }
                else
                    ++i;
                charNum = 0;
                
            }
        }
    }


    public void Init(Shy_Deck _sDeck, bool _isDice)
    {
        inven.SetActive(true);

        deck = _sDeck;
        diceChange = _isDice;

        deck.diceDeck.Sort();
        TileDeckSort();


        for (int i = 0; i < (diceChange ? deck.diceDeck.Count : deck.tileDeck.Count); i++)
        {
            Shy_Event_SelectItem item = Instantiate(itemTool);
            item.transform.parent = listParent;
            item.transform.localScale = Vector3.one;
            item.ses = this;
            item.GetComponent<Image>().sprite = diceChange ? dicePrefab : deck.tileDeck[i].image;
        }

        ShowData(0);
    }

    public void ShowData(int _curInt)
    {
        curSelectInt = _curInt;
        itemName.text = /*diceChange ? deck.diceDeck[_curInt]. :*/ deck.tileDeck[_curInt].tileName;
        icon.sprite = deck.tileDeck[_curInt].image;
        itemExplain.text = deck.tileDeck[_curInt].valueFormula;
        for (int i = 1; i <= 3; i++)
        {
            ranks[i - 1].color = deck.tileDeck[_curInt].skillLevel >= i ? levelColor_O : levelColor_X;
        }
    }

    public void SelectItem()
    {
        if (curSelectInt == 99) return;

        inven.SetActive(false);
        Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Event>().SelectEvent(curSelectInt);
    }

    public void CloseTheDeck()
    {
        Debug.Log(inven);
        inven.gameObject.SetActive(false);
        blackPanel.gameObject.SetActive(false);
        Shy_Manager.instance.GetComponentInChildren<Shy_Manager_Turn>().GameInit();
    }
}
