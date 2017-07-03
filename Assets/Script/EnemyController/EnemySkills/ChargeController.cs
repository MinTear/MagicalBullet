using UnityEngine;
using System.Collections;

public class ChargeController : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
        enemy = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Charge 1(Clone)") != null)
        {
            GameObject charge = GameObject.Find("Charge 1(Clone)");
            charge.transform.parent = enemy.transform;
        }	
	}
}
