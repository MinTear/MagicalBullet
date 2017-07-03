using UnityEngine;
using System.Collections;

public class deadTime : MonoBehaviour {

    public float dead_Time;
    float aliveTime = 0;
    public GameObject Star;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (aliveTime >= dead_Time)
        {
            Destroy(this.gameObject);
        }
        aliveTime += Time.deltaTime;
	}
}
