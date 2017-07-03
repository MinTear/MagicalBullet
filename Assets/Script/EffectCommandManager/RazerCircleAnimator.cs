using UnityEngine;
using System.Collections;

public class RazerCircleAnimator : MonoBehaviour {
    float count = 0;
    float size = 0;

	// Use this for initialization
	void Start () {
        this.transform.localScale = new Vector3(size, size, size);
	}
	
	// Update is called once per frame
	void Update () {

        if (count < 40)
        {
            size  = size + 0.05f;
            transform.localScale = new Vector3(size, size, size);
            
        }

        transform.Rotate(Vector3.forward * 2f);
        count++;

	}
}
