using UnityEngine;
using System.Collections;

public class IllusionLaserController : MonoBehaviour {

    GameObject marisa;

	// Use this for initialization
	void Start () {
        if (GameObject.Find("FrontPos") != null)
        {
        marisa = GameObject.Find("FrontPos");
        this.transform.parent = marisa.transform;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || 
            Input.GetKeyUp(KeyCode.L) || Input.GetKeyDown(KeyCode.Period))
        {
                Destroy(this.gameObject);
        }
	
	}
}
