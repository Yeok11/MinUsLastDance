using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EJY
{
    public class Skill_InvolvedTile_Electric : Skill_Involved
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

        public override void SkillActivated()
        {
            for (int i = 0; i < roopValue;)
            {
                int rand = Random.Range(0, smt.tileObjs.Count);

                if (smt.tileObjs[rand].enemySkillData == null)
                {
                    Debug.Log(rand);
                    var data = ScriptableObject.CreateInstance<Skilldata_SO>();
                    data.Init(lifeValue, this);
                    smt.tileObjs[rand].enemySkillData = data;

                    smturn.enemySkills.Add(data);
                    
                    ++i;
                }   
            }
        }

        public override void SkillEffect()
        {
            _playHealth.TakeDamage(10);
        }
    }
}
