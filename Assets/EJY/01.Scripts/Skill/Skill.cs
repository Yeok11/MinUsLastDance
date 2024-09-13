using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public abstract class Skill : MonoBehaviour
    {
        protected Health _playHealth;
        protected EnemyStatSO _enemyStatSO;

        private void Awake()
        {
            _playHealth = FindObjectOfType<Shy_Player>().GetComponent<Health>();
            _enemyStatSO = GetComponentInParent<EJY_Enemy>().stat;
        }


        public abstract bool CanUseSkill();

        public abstract void UseSkill();
    }
}
