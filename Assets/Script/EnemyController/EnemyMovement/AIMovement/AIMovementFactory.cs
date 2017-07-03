
using UnityEngine;

namespace Assets.Script.EnemyController.EnemyMovement.AIMovement
{
    public static class AIMovementFactory
    {
        private static IAiMovement[] Movements = {new RotateWithPlayerAxisMovement(),new AproachToPlayer(),new DisaproachFromPlayer() };
        public static IAiMovement getRandomAIMovement()
        {
            return Movements[Random.Range(0, Movements.Length)];
        }
    }

    public interface IAiMovement
    {
        float MovementTime { get; }
        void BeginMovement(float time, GameObject me, GameObject player);

        void Move(float time,GameObject me,GameObject player);
    }
}
