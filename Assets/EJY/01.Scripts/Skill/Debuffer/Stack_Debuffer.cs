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

        public override Shy_Stack_Effect Init(Transform _target)
        {
            Shy_Stack_Effect s = Instantiate(this, _target);
            foreach (var dice in _diceList)
            {
                dice.bonusValue--;
            }
            s.actionType = STACKACTION_TYPE.PASSIVE;

            return s;
        }

        public override bool IsDestroy()
        {
            return true;
        }

        public override void DestroyEvent()
        {
        }

        public override void OnEffect()
        {
        }
    }
}

