using UnityEngine;
using System.Collections;

public class CameraRotating : MonoBehaviour {
	public GameObject Camera;
	Vector3 Rotation;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			Camera.transform.Rotate(new Vector3(0,-3,0));
	}
		if(Input.GetKey(KeyCode.RightArrow)){
			Camera.transform.Rotate(new Vector3(0,3,0));
		}
}
}