using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SKillBasicSO")]
public class EJD_SkillBasicSO : ScriptableObject
{
    [Header("InCardChange")]
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Sprite _iconImage;
    [SerializeField] private TextMeshProUGUI _explan;

    [Header("CardStat")]
    [SerializeField] private bool isCanUpgarde;

    [SerializeField] private int[] _gradeValN = new int[3];
    [SerializeField] private int[] gradeValS = new int[3];

    private int _nowUpgrade;

    int damage = 0;

    private void Awake()
    {
        
    }

    private void AttackEnemy(int N, int attackTrying)
    {
        damage += (N * attackTrying);
        return;
    }

    private void GetShield(int N, int plusShield)
    {

    }

    private void GetHeal(int N, int healValue)
    {

    }
}