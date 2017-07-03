using UnityEngine;
using System.Collections;

namespace MagicalBullet.Common
{
    public class DeadTime : MonoBehaviour
    {
        public float TimeInDead;

        void Awake()
        {
            Destroy(gameObject,TimeInDead);
        }
    }
     
}