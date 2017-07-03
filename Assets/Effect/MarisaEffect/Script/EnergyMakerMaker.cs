using UnityEngine;
using System.Collections;

public class EnergyMakerMaker : MonoBehaviour {
    
    public GameObject EnergyMaker;
    public GameObject EnergyShot;
    bool existEnergyShot = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {


        if (!existEnergyShot && Input.GetKeyDown(KeyCode.Period))
        {
            Instantiate(EnergyMaker, this.transform.position, this.transform.rotation);
            Instantiate(EnergyShot, this.transform.position, this.transform.rotation);
            existEnergyShot = true;
        }

        if (existEnergyShot && !GameObject.Find("EnergyMaker(Clone)"))
        {
            existEnergyShot = false;
        }
	
	}
}
