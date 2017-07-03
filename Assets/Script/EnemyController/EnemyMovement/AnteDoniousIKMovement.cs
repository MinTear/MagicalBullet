using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Script.EnemyController.EnemyMovement.AIMovement;
using UnityEngine;

namespace Assets.Script.EnemyController.EnemyMovement
{
    public class AnteDoniousIKMovement:EnemyMovementBase
    {
        public float minLength = 5;

        public float maxLength = 15;

        public float speed = 1.0f;

        private IAiMovement currentMovement;

        private float movementBegin = 0;

        private float movementEnd = 0;

        private GameObject player;

        public override void MoveEnemy(bool isNoticed, GameObject player)
        {
            player = player ?? GameObject.FindGameObjectWithTag("Player");
            if(player==null)return;
            if (isNoticed)
            {
                float length = (player.transform.position - this.transform.position).magnitude;
                Vector3 wEnemy2Player = player.transform.position - this.transform.position;
                wEnemy2Player.Normalize();
                if (!IsInRangeAboutLength(length))
                {
                    currentMovement = null;
                    if (length > maxLength)
                    {
                        //プレイヤーのほうへ近寄る

                        this.transform.position += wEnemy2Player*speed;
                    }

                    else if (length < minLength)
                    {
                        this.transform.position -= wEnemy2Player*speed;
                    }


                }
                else
                {
                    if (movementEnd < Time.time && currentMovement != null)
                    {
                        //現在移動中だが移動終了時間になったとき
                        currentMovement = null;
                    }
                    if (currentMovement == null)
                    {
                        currentMovement = AIMovementFactory.getRandomAIMovement();
                        movementBegin = Time.time;
                        movementEnd = movementBegin + currentMovement.MovementTime;
                        currentMovement.BeginMovement(Time.time, this.gameObject, player);
                    }
                    else
                    {
                        currentMovement.Move(Time.time, gameObject, player);
                    }
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
