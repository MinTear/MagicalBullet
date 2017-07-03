using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = System.Random;

namespace Assets.Script.EnemyController.EnemySkills
{
    internal class RandomSkillSelector : SkillSelectorBase
    {
        public override EnemySkillBase SelectSkill(EnemySkillBase[] skills)
        {
            if (skills.Length != 0)
            {
                Random rand = new Random();
                return skills[rand.Next(skills.Length)];
            }
            return null;
        }
    }
}
