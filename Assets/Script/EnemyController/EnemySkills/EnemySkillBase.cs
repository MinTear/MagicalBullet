using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.EnemyController.EnemySkills
{
    public abstract class EnemySkillBase:MonoBehaviour
    {
        [HideInInspector]
        public NewEnemyBehaviour ParentEnemyBehaviour;

        public abstract float SkillTime { get; }

        public bool NeedFreeze;

        public abstract void OnSkillBegin();
        public abstract void OnSkillUpdate(float timeInSkill);
    }
}
