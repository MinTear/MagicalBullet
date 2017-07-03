using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.EnemyController.LockonDetecter
{
    public abstract class LockonDetectorBase:MonoBehaviour
    {
        public abstract bool IsNoticed { get; }
    } 
}
