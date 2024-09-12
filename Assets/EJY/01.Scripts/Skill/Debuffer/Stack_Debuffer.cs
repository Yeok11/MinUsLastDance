using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EJY
{
    public class Stack_Debuffer : Shy_Stack_Effect
    {
        [SerializeField] private Transform DicesTrm;
        List<Shy_Dice> _diceList;
        private void Awake()
        {
            _diceList = DicesTrm.GetComponentsInChildren<Shy_Dice>().ToList();
        }
        public override void Init()
        {
            foreach (var dice in _diceList)
            {
                dice.bonusValue--;
            }
        }

        public override bool IsDestroy()
        {
            return true;
        }

        public override void DestroyEvent()
        {
        }
    }
}

