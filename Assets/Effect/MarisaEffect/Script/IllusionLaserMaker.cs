using UnityEngine;
using System.Collections;

public class IllusionLaserMaker : MonoBehaviour {

    public GameObject IllusionLaser;
 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.L) && !Input.GetKeyDown(KeyCode.J) && !Input.GetKeyDown(KeyCode.K) &&
            !MasterSparkMakerMaker.ExistLaser && !StarMakerMaker.ExistStar)
        {
            if (GameObject.FindGameObjectsWithTag("IllusionLaser").Length < 2)
            {
                Instantiate(IllusionLaser, this.transform.position, this.transform.rotation);
            }
        }
	}
}
