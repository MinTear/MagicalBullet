
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Script.EnemyController.EnemySkills.MarkAttackSetter;
using UnityEngine;

namespace Assets.Script.EnemyController.EnemySkills
{
    class MarkerAttackSkill:EnemySkillBase
    {
        public GameObject SetObject;

        public int MaxSetCount = 4;

        public int SkillTimeInSecound = 10;

        private GameObject Player;

        private float _skillTime;

        private int setCount = 0;

        private IMarkAttackSetter marksetter;

        public override float SkillTime
        {
            get { return SkillTimeInSecound; }
        }

        public override void OnSkillBegin()
        {
            this.Player = GameObject.FindGameObjectWithTag("Player");
            marksetter = 
                MarkAttackSetterFactory.GetRandomMarkAttackSetter();
            setCount = 0;
            marksetter.BeginSetMarks(0, this.gameObject);
        }

        public override void OnSkillUpdate(float timeInSkill)
        {
            marksetter.SetMarks(timeInSkill, SetObject, this, Player);
        }
    }
}
