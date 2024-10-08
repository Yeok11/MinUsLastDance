using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shy_Player : Shy_Character
{
    public Shy_Stack_Cnt hunt;
    public Shy_Stack_Cnt mana;
    [SerializeField] private Transform stackPos;
    private Health health;
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private Image bar;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        tmp.text = health._currentHp + " / " + health._maxHp;
        bar.fillAmount = health._currentHp / health._maxHp;
    }


    public void SetStack(COUNT_STACK_TYPE _type, int _value)
    {
        foreach (Shy_Stack_Cnt item in stacks)
        {
            if(item.stackName == _type.ToString())
            {
                item.count += _value;
                return;
            }
        }


        //¾ø´Ù¸é
        Shy_Stack_Cnt stc;
        
        if(_type == COUNT_STACK_TYPE.MANA)
        {
            stc = Instantiate(mana);
            stc.stackSprite = mana.stackSprite;
        }
        else
        {
            stc = Instantiate(hunt);
            stc.stackSprite = hunt.stackSprite;
        }
        stc.count = _value;
        stc.stackName = _type.ToString();

        stc.transform.parent = stackPos;
        stc.transform.localScale = Vector3.one;
        stacks.Add(stc);
    }
}
