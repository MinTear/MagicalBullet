using UnityEngine;
using System.Collections;

public class DestroyBeam : MonoBehaviour {

    GameObject BeamDestroy;
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy-Effect"))
        {
            BeamDestroy = GameObject.FindGameObjectWithTag("Enemy-Effect");
            Destroy(BeamDestroy);
        }
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
