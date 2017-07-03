using UnityEngine;
using System.Collections;

public class DebugCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    if (GameObject.FindObjectOfType(typeof (Camera)) == null)
	    {
            Camera camera=new Camera();
	        Instantiate(camera, new Vector3(0, 0, 0), Quaternion.identity);
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
