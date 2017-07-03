using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.EnemyController.EnemySkills
{
    public abstract class SkillSelectorBase:MonoBehaviour
    {
        public abstract EnemySkillBase SelectSkill(EnemySkillBase[] skills);
    }
}
