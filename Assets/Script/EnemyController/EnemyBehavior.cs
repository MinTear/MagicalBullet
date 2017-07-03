using Assets.Extention;
using Assets.Script.EnemyController.LockonDetecter;
using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
    public LockonDetectorBase LockonDetector;

    GameObject Player;
    public GameObject[] shotPos;
    public GameObject Enemy;
    public GameObject Beam;
    public GameObject Charge;
    public float PlayerDistance = 3f;
    public Rigidbody targetRigidBody;
    public bool LockOn = false;
    bool _shot = false;
    bool rest = false;
    float interval_time = 0;
    float reaction = 0;
    int count=0;

	// Use this for initialization
	void Start ()
	{
	    this.Player = this.GetPlayer();
	}
	
	// Update is called once per frame
	void Update () {
      //if(LockOn)
      //{

      //    var rigitBody = targetRigidBody;
      //    Vector3 playerPositionInLocal = transform.transform.worldToLocalMatrix.MultiplyPoint(Player.transform.position);
      //    if (playerPositionInLocal.magnitude > 5f)
      //    {
      //        rigitBody.velocity=playerPositionInLocal.normalized*10;
      //    }
      //    else
      //    {
      //        targetRigidBody.velocity =- playerPositionInLocal.normalized * 10;
      //    }
      //}
      //else
      //{
      //    if((Player.transform.position-targetRigidBody.transform.position).magnitude<20f)
      //    {
      //        Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, Quaternion.LookRotation(Player.transform.position - Enemy.transform.position), 0.1f);
      //    }
      //    targetRigidBody.velocity = Vector3.zero;
      //}
       
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           Player = GameObject.FindGameObjectWithTag("Player");
           LockOn = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (LockOn)
            {
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, Quaternion.LookRotation(Player.transform.position - Enemy.transform.position), 0.1f);

            }

            //if (!shot && !rest)
            //{
            //    interval += Time.deltaTime;
            //    if (interval >= 4)
            //    {
            //        LockOn = false;
            //        shot = true;
            //        interval = 0;
            //    }
            //}

            if (_shot && !rest)
            {
                if (count == 0)
                {
                    foreach (var charge in shotPos)
                    {
                        Instantiate(Charge, charge.transform.position, charge.transform.rotation);
                    }
                }
                count++;
                if (count >= 30)
                {
                    foreach (var charge in shotPos)
                    {
                        Instantiate(Beam, charge.transform.position,charge.transform.rotation);
                    }

                    rest = true;
                    _shot = false;
                    count = 0;
                }

            }
            else
            {
                _shot = true;
            }

            if (rest)
            {
                reaction += Time.deltaTime;

                if (reaction >= 2.5)
                {
                    rest = false;
                    LockOn = true;
                    reaction = 0;
                }
            }
        }

        
    }

    void OnTriggerExit()
    {
        LockOn = false;
        _shot = false;
        interval_time = 0;
    }
}
