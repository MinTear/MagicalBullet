using UnityEngine;
using System.Collections;

public class ObjectDestroyed_in_selecting : MonoBehaviour
{
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(this.gameObject);
        }
	
	}
}
