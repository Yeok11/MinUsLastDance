using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shy_Manager_Event : MonoBehaviour
{
    //mes
    //[SerializeField] private TextMeshProUGUI title;
    //[SerializeField] private TextMeshProUGUI contants;

    //bts
    [SerializeField] private List<Button> btns;
    [SerializeField] private GameObject blackPanel;

    //other
    [SerializeField] private List<Shy_Event_Selector> events;
    [SerializeField] private GameObject deckUI;
    [SerializeField] private GameObject eventUI;
    [SerializeField] private EVENT_TYPE curEventType;

    //Managers
    [SerializeField] private Shy_Deck deck;

    int eventNumber = 0;

    private void Start()
    {
        deck = FindObjectOfType<Shy_Deck>();
    }

    public void ResultEvent()
    {
        eventUI.gameObject.SetActive(true);
        blackPanel.gameObject.SetActive(true);

        //이벤트 선택
        eventNumber = PerCalculator(true);

        //bt 미리꺼놓기
        for (int i = 0; i < btns.Count; i++)
            btns[i].gameObject.SetActive(false);

        //txt 세팅
        //title.text = events[eventNumber].titleMes;
        //contants.text = events[eventNumber].contatnsMes;

        //+bt 켜기
        int eventCnt = events[eventNumber].selectList.Count;
        if (eventCnt != 1)
        {
            for (int i = 0; i < eventCnt; i++)
            {
                btns[i].gameObject.SetActive(true);
                btns[i].GetComponentInChildren<TextMeshProUGUI>().text = events[eventNumber].selectList[i].mes;
            }
        }
        else
        {
            btns[0].gameObject.SetActive(true);
            btns[0].GetComponentInChildren<TextMeshProUGUI>().text = events[eventNumber].selectList[0].mes;
        }
    }

    private int PerCalculator(bool _isSetEvent, int _dataNum = 0)
    {
        int totalValue = 0, n = 0;
        List<int> perTotal = new List<int>();

        if (!_isSetEvent)
            foreach (var item in events[eventNumber].selectList[_dataNum].data)
            {
                totalValue += item.per;
                perTotal.Add(item.per);
            }
        else if (_isSetEvent)
            foreach (var item in events)
            {
                totalValue += item.per;
                perTotal.Add(item.per);
            }

        totalValue = Random.Range(1, totalValue + 1);

        while (true)
        {
            totalValue -= perTotal[n];

            if (totalValue <= 0) return n;
            else ++n;
        }
    }

    public void ActionEvent(int _value)
    {
        Debug.Log("value : " + _value + " / type : " + events[eventNumber].selectList[_value].type);
        Shy_Event_Data evData = events[eventNumber].selectList[_value];
        curEventType = evData.type;
        switch (curEventType)
        {
            case EVENT_TYPE.NONE:
                break;
            case EVENT_TYPE.GET_CARD:
                TileEventRandom(true, _value);
                break;
            case EVENT_TYPE.UPGRADE_CARD:
                SelectEvent();
                break;
            case EVENT_TYPE.DEL_CARD:
                SelectEvent();
                break;
            case EVENT_TYPE.GET_DICE:
                DiceEventRandom(true, _value);
                break;
            case EVENT_TYPE.DEL_DICE:
                SelectEvent();
                break;
            case EVENT_TYPE.CHANGE_HEALTH:
                break;
            case EVENT_TYPE.HEAL:
                EffectPlayerHp(evData.data[PerCalculator(false, _value)].value);
                break;
            case EVENT_TYPE.DAMAGE:
                EffectPlayerHp(evData.data[PerCalculator(false, _value)].value * -1);
                break;
            case EVENT_TYPE.UPGRADE_CARD_RAND:
                break;
            case EVENT_TYPE.DEL_CARD_RAND:
                TileEventRandom(false, _value);
                break;
            case EVENT_TYPE.DEL_DICE_RAND:
                DiceEventRandom(false, _value);
                break;
        }
    }

    public void SelectEvent(int _selectNum = 99)
    {
        if(_selectNum == 99)
        {
            CloseTheEvent();
            GetComponent<Shy_Event_Select>().Init(deck, curEventType.ToString().Contains("DICE"));
            return;
        }

        switch (curEventType)
        {
            case EVENT_TYPE.UPGRADE_CARD:
                deck.tileDeck[_selectNum].skillLevel += 1;
                break;
            case EVENT_TYPE.DEL_CARD:
                deck.tileDeck.RemoveAt(_selectNum);
                break;
            case EVENT_TYPE.DEL_DICE:
                break;
        }
    }

    private void DiceEventRandom(bool _get, int _dataNum)
    {
        Shy_DiceSO diceSO = new Shy_DiceSO();
        if(_get)
        {
            diceSO = ScriptableObject.CreateInstance<Shy_DiceSO>();
            Shy_DiceSO s = events[eventNumber].selectList[_dataNum].data[PerCalculator(false, _dataNum)].objSO as Shy_DiceSO;
            diceSO.eyes = s.eyes;
            diceSO.cost = s.cost;

            deck.diceDeck.Add(diceSO);
        }
        else
        {
            if(deck.diceDeck.Count > 5)
            {
                deck.diceDeck.RemoveAt(Random.Range(0, deck.diceDeck.Count));
            }
        }
    }

    private void TileEventRandom(bool _get, int _dataNum)
    {
        if (_get)
        {
            Shy_TileSO s = events[eventNumber].selectList[_dataNum].data[PerCalculator(false, _dataNum)].objSO as Shy_TileSO;
            Shy_TileSO tileSO = new Shy_TileSO(s);

            deck.tileDeck.Add(tileSO);
        }
        else
        {
            if (deck.tileDeck.Count > 0)
            {
                deck.diceDeck.RemoveAt(Random.Range(0, deck.tileDeck.Count));
            }
        }

        CloseTheEvent(0);

    }


    //Damage와 Heal 함수
    private void EffectPlayerHp(int _value)
    {
        //PlayerHp + _value;
    }

    public void CloseTheEvent(int bt = -1)
    {
        if (bt != -1)
        {
            blackPanel.SetActive(false);
            transform.parent.GetComponentInChildren<Shy_Manager_Turn>().NewGame();
        }
        eventUI.SetActive(false);
    }
}