using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.EnemyController
{
    class PlayerChaser4Enemy:IEnemyLockOnBehavior
    {
        private Rigidbody targetRigidBody;
        public void Start()
        {
            this.targetRigidBody=this.gameObject.GetComponent<Rigidbody>();
        }

        public override void OnLockOn()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
             var rigitBody = targetRigidBody;
            Vector3 playerPositionInLocal = transform.transform.worldToLocalMatrix.MultiplyPoint(player.transform.position);
            Vector3 force = playerPositionInLocal.normalized;
            force.y = 0;
            force *= 5.0f;
            rigidbody.velocity = force;
        }
    }
}
