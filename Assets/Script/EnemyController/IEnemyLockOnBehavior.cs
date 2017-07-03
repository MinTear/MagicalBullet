using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.EnemyController
{
    public abstract class IEnemyLockOnBehavior:MonoBehaviour
    {
       public abstract void OnLockOn();
    }
}
