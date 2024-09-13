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

        public override void SkillEffectByTurn()
        {
            _playHealth.TakeDamage(10);
        }

        public override void UseSkill()
        {
            for (int i = 0; i < roopValue;)
            {
                int rand = Random.Range(0, smt.tileObjs.Count);

                if (smt.tileObjs[rand].enemySkillData == null)
                {
                    var data = ScriptableObject.CreateInstance<InvolvedSkillData_SO>();
                    data.Init(lifeValue, this);
                    smt.tileObjs[rand].enemySkillData = data;

                    smturn.enemySkills.Add(data);

                    ++i;
                }
            }
        }
    }
}
