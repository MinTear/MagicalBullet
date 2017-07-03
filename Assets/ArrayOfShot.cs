using UnityEngine;
using System.Collections;

public class ArrayOfShot : MonoBehaviour {
    public float fowardSpeed = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Translate(Vector3.up *Time.deltaTime * fowardSpeed);
	
	}
}
