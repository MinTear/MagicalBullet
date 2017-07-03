using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Script.Common.TransitionFunction;
using UnityEngine;

namespace Assets.Script.EnemyController.EnemyMovement.AIMovement
{
    class DisaproachFromPlayer:IAiMovement
    {
        private float beginTime;
        public float MovementTime
        {
            get { return 10; }
        }

        public void BeginMovement(float time, GameObject me, GameObject player)
        {
            beginTime = time;
        }

        public void Move(float time, GameObject me, GameObject player)
        {
            float progress = (Time.time - beginTime) / MovementTime;
            Vector3 enemy2player = me.transform.position - player.transform.position;
			enemy2player.Normalize ();
			enemy2player = enemy2player * Random.Range (1, 5);
            me.transform.position = Vector3.Lerp(me.transform.position, me.transform.position - enemy2player,
                TransitionFunctionFactory.GetRandomTransitionFunction().Transit(progress));
        }
    }
}
