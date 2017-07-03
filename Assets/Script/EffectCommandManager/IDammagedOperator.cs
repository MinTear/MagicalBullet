using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.EffectOperate
{
    interface IDammagedOperator
    {
        void dammagedManager(float damagePoint);
        void isCollisionManager();
        void isGroundedManager(GameObject effect);

    }
}
