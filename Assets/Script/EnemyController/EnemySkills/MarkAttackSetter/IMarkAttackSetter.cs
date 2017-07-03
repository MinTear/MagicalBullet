
//sing MMD4MecanimInternal.Bullet;
using UnityEngine;

namespace Assets.Script.EnemyController.EnemySkills.MarkAttackSetter
{
    public interface IMarkAttackSetter
    {
        void SetMarks(float time,GameObject gameSource,MonoBehaviour me,GameObject player);

        void BeginSetMarks(float time,GameObject me);
    }

    public static class MarkAttackSetterFactory
    {
        private static IMarkAttackSetter[] markSetters={new CircleAttackSetter(),new BasicMarkAttackSetter(),new HorizontalLineAttackSetter(10),new VerticalLineAttackSetter(10),new CrossLineAttackSetter(),   };
        public static IMarkAttackSetter GetRandomMarkAttackSetter()
        {
            return markSetters[Random.Range(0, markSetters.Length)];
        }
    }

    public abstract class MarkAttackSetterBase : IMarkAttackSetter
    {
        public EnemyMarkAttack InstantinateEnemyMarkAttack(GameObject gameObject)
        {
            GameObject instantiated = (GameObject)Object.Instantiate(gameObject,new Vector3(1000,0,0), 
             Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up));
            var ema = instantiated.GetComponent<EnemyMarkAttack>();
            return ema; 
        }
        public abstract void SetMarks(float time, GameObject gameSource, MonoBehaviour me, GameObject player);
        public abstract void BeginSetMarks(float time, GameObject me);
    }

    public class BasicMarkAttackSetter : MarkAttackSetterBase
    {
        private int setCount = 0;
        public override void SetMarks(float time, GameObject gameSource, MonoBehaviour me, GameObject player)
        {
            if (setCount < time&&setCount<4)
            {
                Vector3 targetPosition = player.transform.position;
                targetPosition.y = 0.1f;
                GameObject instantiated = (GameObject)Object.Instantiate(gameSource, targetPosition,
                    Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up));
                var ema = instantiated.GetComponent<EnemyMarkAttack>();
                if (ema != null)
                {
                    Vector3 sourcePosition = me.transform.position;
                    sourcePosition.y = 0.1f;
                    ema.TargetPosition = targetPosition;
                    ema.SourcePosition = sourcePosition;
                }
                setCount++;
            }
        }
        

        public override void BeginSetMarks(float time, GameObject me)
        {
            setCount = 0;
        }
        }

    public class VerticalLineAttackSetter : MarkAttackSetterBase
    {
        public VerticalLineAttackSetter(int instantinateCount)
        {
            this.instantinateCount = instantinateCount;
        }

        private int instantinateCount = 10;
        private bool toSet = false;
        public override void SetMarks(float time, GameObject gameSource, MonoBehaviour me, GameObject player)
        {
            if (toSet)
            {
                toSet = false;
                Vector3 me2player = player.transform.position - me.transform.position;
                Vector3 playerInStair = player.transform.position;

                for (int i = 0; i < instantinateCount; i++)
                {
                    Vector3 toPos=(me2player*2)/(instantinateCount + 1);
                    toPos.y = 0;
                    EnemyMarkAttack attack = InstantinateEnemyMarkAttack(gameSource);
                    Vector3 mePosInStair = me.transform.position;
                    mePosInStair.y = 0.1f;
                    attack.SourcePosition = mePosInStair;
                    attack.TargetPosition =mePosInStair + toPos*i;
                }
            }
        }


        public override void BeginSetMarks(float time, GameObject me)
        {
            toSet = true;
        }
    }

    public class HorizontalLineAttackSetter : MarkAttackSetterBase
    {
        private int instantinateCount = 10;
        private bool toSet = false;

        public HorizontalLineAttackSetter(int instantinateCount)
        {
            this.instantinateCount = instantinateCount;
        }

        public override void SetMarks(float time, GameObject gameSource, MonoBehaviour me, GameObject player)
        {
            if (toSet)
            {
                toSet = false;
                Vector3 me2player = player.transform.position - me.transform.position;
                Vector3 playerInStair = player.transform.position;
                playerInStair.y = 0.1f;
                for (int i = -instantinateCount/2; i < instantinateCount/2; i++)
                {
                    Vector3 toPos = (me2player * 2) / (instantinateCount + 1);
                    toPos.y = 0;
                    toPos.Normalize();
                    toPos = Vector3.Cross(toPos, Vector3.up);
                    EnemyMarkAttack attack = InstantinateEnemyMarkAttack(gameSource);
                    Vector3 mePosInStair = me.transform.position;
                    mePosInStair.y = 0.1f;
                    attack.SourcePosition = mePosInStair;
                    attack.TargetPosition = playerInStair+ toPos * i;
                }
            }
        }


        public override void BeginSetMarks(float time, GameObject me)
        {
            toSet = true;
        }
    }
    public class CrossLineAttackSetter : MarkAttackSetterBase
    {
        private VerticalLineAttackSetter vertical=new VerticalLineAttackSetter(8);

        private HorizontalLineAttackSetter horizontal=new HorizontalLineAttackSetter(8);

        public CrossLineAttackSetter()
        {
            
        }

        public override void SetMarks(float time, GameObject gameSource, MonoBehaviour me, GameObject player)
        {
            vertical.SetMarks(time, gameSource,me,player);
            horizontal.SetMarks(time,gameSource,me,player);
        }


        public override void BeginSetMarks(float time, GameObject me)
        {
           vertical.BeginSetMarks(time,me);
            horizontal.BeginSetMarks(time,me);
        }
    }

    public class CircleAttackSetter : MarkAttackSetterBase
    {
        private bool toSet;
        public CircleAttackSetter()
        {

        }

        public override void SetMarks(float time, GameObject gameSource, MonoBehaviour me, GameObject player)
        {
            if (toSet)
            {
                toSet = false;
                Vector3 me2player = player.transform.position - me.transform.position;
                me2player.Normalize();
                Vector3 rotrationFactor = -me2player;
                Vector3 playerOnStair = player.transform.position;
                playerOnStair.y = 0.1f;
                for (int i = 0; i < 11; i++)
                {
                    EnemyMarkAttack attack = InstantinateEnemyMarkAttack(gameSource);
                    Vector3 mePosInStair = me.transform.position;
                    mePosInStair.y = 0.1f;
                    attack.SourcePosition = mePosInStair;
                    Matrix4x4 transformMat = Matrix4x4.TRS(Vector3.zero,
                        Quaternion.Slerp(Quaternion.identity, Quaternion.AngleAxis(180, Vector3.up),i*0.2f),
                        new Vector3(1, 1, 1));

                    attack.TargetPosition = playerOnStair + transformMat.MultiplyVector(rotrationFactor)*10;
                }
            }
        }


        public override void BeginSetMarks(float time, GameObject me)
        {
            toSet = true;
        }
    }


    }
