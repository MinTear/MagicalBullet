using UnityEngine;
using System.Collections;

public class StarRainMakerMaker : MonoBehaviour {
    public GameObject StarRainMaker;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Slash))
        {

            Instantiate(StarRainMaker, this.transform.position, this.transform.rotation);

        }
	
	}
}
