using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public abstract class Skill : MonoBehaviour
    {
        public Health _playHealth;
        public EnemyStatSO _enemyStatSO;

        public Sprite icon;

        protected virtual void Awake()
        {
            _playHealth = FindObjectOfType<Shy_Player>().GetComponent<Health>();
            _enemyStatSO = GetComponentInParent<EJY_Enemy>().stat;
        }


        public abstract bool CanUseSkill();

        public abstract void UseSkill();
    }
}
