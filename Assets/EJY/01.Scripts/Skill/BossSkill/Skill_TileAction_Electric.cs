using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_TileAction_Electric : Skill_Involved
    {
        public int roopValue = 5;
        public int lifeValue = 2;

        protected override void Start()
        {
            base.Start();
        }

        public override bool CanUseSkill()
        {
            return true;
        }

        public void FirstSkill()
        {
            _playHealth.TakeDamage(10);
        }

        public override void InvolvedEffectSkill()
        {
            throw new System.NotImplementedException();
        }

        public override void UseSkill()
        {
            for (int i = 0; i < roopValue;)
            {
                int rand = Random.Range(0, smtile.tileObjs.Count);

                if (smtile.tileObjs[rand].enemySkillData == null)
                {
                    Debug.Log(rand);
                    var data = ScriptableObject.CreateInstance<InvolvedSkillData_SO>();
                    data.Init(lifeValue, this);
                    smtile.tileObjs[rand].enemySkillData = data;

                    smturn.tileEventByEnemy.Add(data);

                    ++i;
                }
            }
        }
    }
}
