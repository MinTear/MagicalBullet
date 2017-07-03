using UnityEngine;
using System.Collections;

public class Lock_On_Function : MonoBehaviour {

    GameObject character;
    GameObject enemy;
    bool lock_on = false;
	// Use this for initialization
	void Start () {
        character = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
        if (lock_on)
        {

        }
	
	}

    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.CompareTag("Enemy"))
        {
            lock_on = true;
            enemy = col.gameObject;
            
        }
    }
}
