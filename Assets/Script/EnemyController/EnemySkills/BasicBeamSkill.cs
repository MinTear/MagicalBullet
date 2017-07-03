using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.EnemyController.EnemySkills
{
    class BasicBeamSkill:EnemySkillBase
    {
        public GameObject Beam;
        public GameObject Charge;
        public GameObject[] ShotPositions;

        private BasicBeamState state=BasicBeamState.Beginning;
        public override float SkillTime
        {
            get { return 6; }
        }

        public override void OnSkillBegin()
        {
            state = BasicBeamState.Beginning;
        }

        public override void OnSkillUpdate(float timeInSkill)
        {
            if (state == BasicBeamState.Beginning)
            {
                foreach (var shotPosition in ShotPositions)
                {
                    Instantiate(Charge, shotPosition.transform.position, shotPosition.transform.rotation);
                }
                state = BasicBeamState.Charging;
            }
            if (state == BasicBeamState.Charging && timeInSkill > 1.0f)
            {
                state = BasicBeamState.Shotting;
                foreach (var shotPosition in ShotPositions)
                {
                    Instantiate(Beam, shotPosition.transform.position, shotPosition.transform.rotation);
                }
            }
            if (state == BasicBeamState.Shotting)
            {
                if (timeInSkill > 3)
                {
                    state = BasicBeamState.Finished;
                }
            }
        }
    }


    enum BasicBeamState
    {
        Charging,Shotting,Beginning,Finished
    }
}
