using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

    public float rotate = 5f;
    public float speed = 1f;

	// Use this for initialization
	void Start () {
        transform.rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * rotate);
	}
}
