using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Extention
{
    public static class MonoBehaviourExtention
    {
        public static GameObject GetPlayer(this MonoBehaviour monoBehaviour)
        {
            return GameObject.FindGameObjectWithTag("Player");
        }
    }
}
