using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace EJY
{
    public class Skill_Bomb_Barrier : Skill_Barrier
    {
        [SerializeField] private Transform _stack;

        private float weightBarrier;
        private Shy_Stack_Effect _bomb;

        public override void Awake()
        {
            base.Awake();
        }
        public override bool CanUseSkill()
        {
            return true;
        }

        public override void UseSkill()
        {
            _bomb = _stack.GetComponentInChildren<Shy_Stack_Effect>();
            if (_bomb != null)
            {
                _bomb.IsDestroy();
                _bomb.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = (_bomb.life).ToString();
            }

            weightBarrier = _enemyStatSO._hp / 2;
            target.HealthCompo.GetBarrier(weightBarrier);

        }
    }
}

