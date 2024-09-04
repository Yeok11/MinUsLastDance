using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* 림버스 랜덤 인카운터 구현*/
public enum Behaviors
{
    getItem,
    fightEnemy,
    move,
    Upgrade
}
public class EJD_ShowEncounter : MonoBehaviour
{
    string s;

    public Behaviors bh = new Behaviors();

    [SerializeField] private GameObject _selection;
    [SerializeField] private GameObject[] _selectionPos;
    [SerializeField] private TMP_Text _encounterStroy;

    private int a;

    public string Show(string tag)
    {
        s = tag;

        return s;
    }

    public void LogManage(string log)
    {
        switch (bh)
        {
            case Behaviors.getItem:
                log = $"{s} Get.\n You want get it?";
                break;
            case Behaviors.fightEnemy:
                log = $"Player encounters {s}.\n Will you fight{s}";
                break;
            case Behaviors.move:
                log = $"You will go to {s}";
                break;
        }
        _encounterStroy.text = log;
        if (a < 1)
            CreateSelection();
    }

    public void CreateSelection()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject selection = Instantiate(_selection);
            selection.name = $"{i}";
            selection.transform.SetParent(_selectionPos[i].transform);
            selection.transform.position = _selectionPos[i].transform.position;
            selection.SetActive(true);

        }
        a++;
    }
}