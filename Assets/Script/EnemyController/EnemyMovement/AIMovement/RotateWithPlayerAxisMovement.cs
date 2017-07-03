
using Assets.Script.Common.TransitionFunction;
//using MMD4MecanimInternal.Bullet;
using UnityEngine;

namespace Assets.Script.EnemyController.EnemyMovement.AIMovement
{
    class RotateWithPlayerAxisMovement:IAiMovement
    {
        private float beginTime;

        private bool isRight;
        private Quaternion rotate;

        public float MovementTime
        {
            get { return 5; }
        }

        public void BeginMovement(float time, GameObject me, GameObject player)
        {
            beginTime = time;
            isRight = Random.Range(0, 2)==0;
            rotate = Quaternion.AngleAxis(Random.Range((float) (Mathf.PI/10.0),Mathf.PI/4f) * (isRight ? -1 : 1), Vector3.up);
        }

        public void Move(float time, GameObject me, GameObject player)
        {
            float elapsedTime = time - beginTime;
            float elapsedProgress = elapsedTime/MovementTime;
            Vector3 player2me = me.transform.position - player.transform.position;
            Matrix4x4 mat = Matrix4x4.TRS(Vector3.zero, Quaternion.Lerp(Quaternion.identity, rotate,TransitionFunctionFactory.GetRandomTransitionFunction().Transit(elapsedProgress)),
                new Vector3(1, 1, 1));
            Vector3 newplayer2me = mat.MultiplyVector(player2me);
            Vector3 newPosition = player.transform.position + newplayer2me;
            me.gameObject.transform.position = newPosition;
        }
    }
}
