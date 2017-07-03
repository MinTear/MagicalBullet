using UnityEngine;
using System.Collections;

public class MasterSparkMakerMaker : MonoBehaviour {
    
    public GameObject MasterSparkMaker;
    private static bool existLaser = false;

    public static bool ExistLaser { get { return MasterSparkMakerMaker.existLaser; } }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (!existLaser && Input.GetKeyDown(KeyCode.J) && !Input.GetKeyDown(KeyCode.L) && !Input.GetKeyDown(KeyCode.K)
            && !StarMakerMaker.ExistStar)
        {
            Instantiate(MasterSparkMaker, this.transform.position, this.transform.rotation);
            existLaser = true;
        }

        if (existLaser && /*!GameObject.Find("MasterSpark(Clone)") &&*/ !GameObject.Find("MasterSparkMaker(Clone)"))
        {
            existLaser = false;
        }
	}
}
