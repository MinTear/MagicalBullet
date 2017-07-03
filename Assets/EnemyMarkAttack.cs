//using MMD4MecanimInternal.Bullet;
using UnityEngine;
using System.Collections;
using Math = System.Math;

public class EnemyMarkAttack : MonoBehaviour
{

    private float beginTime = 0f;
    public float AttackPrepareTime = 3f;
    public float ChaseTime = 1f;
    public GameObject BombEffect;
    public float lengnthOfArray = 4;
    private GameObject player;
    private Vector3 _targetPosition;
    private Vector3 _sourcePosition;
    

    public Vector3 TargetPosition
    {
        get { return _targetPosition; }
        set { _targetPosition = value; }
    }

    public Vector3 SourcePosition
    {
        get { return _sourcePosition; }
        set { _sourcePosition = value; }
    }

    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    if (beginTime == 0f)
	    {
	        beginTime = Time.time;
	        return;
	    }
	    else
	    {
	        float elapsed = Time.time - beginTime;
	        float positionProgress = Math.Min(ChaseTime, elapsed)/ChaseTime;
	        gameObject.transform.position = Vector3.Lerp(SourcePosition, TargetPosition, positionProgress);
	        if (elapsed > AttackPrepareTime)
	        {
                //爆発の瞬間
                Vector3 player2effect = gameObject.transform.position - player.transform.position;
                if (player2effect.magnitude <= lengnthOfArray)
                {
                    PlayerDamageManager.HP = PlayerDamageManager.HP - (Math.Abs(1 - (player2effect.magnitude / 3)))/5;
                }
	           Instantiate(BombEffect, transform.position, transform.rotation);
	           Destroy(gameObject);
	        }
	        else
	        {
	           gameObject.renderer.material.SetFloat("_Progress",elapsed/AttackPrepareTime);
	        }
	    }
	}
}
