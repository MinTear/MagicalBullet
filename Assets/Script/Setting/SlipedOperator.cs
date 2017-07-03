using UnityEngine;
using System.Collections;

public class SlipedOperator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }
}
