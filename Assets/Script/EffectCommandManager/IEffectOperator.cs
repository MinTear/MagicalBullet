using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.EffectOperate
{
    interface IEffectOperator
    {
        void guardOperator(GameObject character);
        void firstCommandOperator(GameObject character);
        void secondCommandOperator(GameObject character);
        void thirdCommandOperator(GameObject character);

    }
}
