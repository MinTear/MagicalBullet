using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.EnemyController.EnemyMovement
{
    public class AnteDoniousMovement:EnemyMovementBase
    {
        public float minLength = 5;

        public float maxLength = 15;

        public float speed = 1.0f;

        public override void MoveEnemy(bool isNoticed, GameObject player)
        {
            if (isNoticed)
            {
                float length = (player.transform.position - this.transform.position).magnitude;
                Vector3 wEnemy2Player = player.transform.position - this.transform.position;
                wEnemy2Player.Normalize();
                if (!IsInRangeAboutLength(length))

                {

                    if (length > maxLength)
                    {
                        //プレイヤーのほうへ近寄る

                        this.transform.position += wEnemy2Player*speed;
                    }

                    if (length < minLength)
                    {
                        this.transform.position -= wEnemy2Player*speed;
                    }

                }
                else
                {
                    
                }

                //回転
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), 0.07f);
            }
        }

        private bool IsInRangeAboutLength(float length)
        {
            if (minLength > length)
            {
                return false;
            }
            if (maxLength < length)
            {
                return false;
            }
            return true;
        }
    }
}
