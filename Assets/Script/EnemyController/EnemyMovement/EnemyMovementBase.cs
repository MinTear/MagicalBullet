using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.EnemyController.EnemyMovement
{
    public abstract class EnemyMovementBase:MonoBehaviour
    {
        public abstract void MoveEnemy(bool isNoticed, GameObject player);
    }
}
