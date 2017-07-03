using UnityEngine;
using System.Collections;

public class MovingController : MonoBehaviour {

    public float four_way_speed;
    public float verticlal_speed;
    float horizontal, vertical, level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        level = Input.GetAxis("Level");

        this.transform.Translate(horizontal * four_way_speed, level * verticlal_speed, vertical * four_way_speed);
   
      
	}
}
