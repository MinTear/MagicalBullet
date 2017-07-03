using UnityEngine;
using System.Collections;

public class RazerCircleConstructor : MonoBehaviour {

    float size = 0;
    float speed = 0.001f;
    float count = 0;

	// Use this for initialization
	void Start () {
        this.transform.localScale = new Vector3(size, size, size);
	}
	
	// Update is called once per frame
	void Update () {

        if (count < 20)
        {
            size = size + 0.1f;
            transform.localScale = new Vector3(size, size, size);
            transform.Translate(Vector3.forward * speed);

        }

        count++;
	
	}
}
