using UnityEngine;
using System.Collections;

public class MasterSparkMaker : MonoBehaviour {

    int count = 0;
    float fcount = 0f;
    float maspaSize = 0;
    bool isCount = true;
    bool isShot = true;
    GameObject marisa;
    public GameObject MasterSpark;

	// Use this for initialization
	void Start () {
        //if (GameObject.Find("FrontPos") != null)
        //{
        //    marisa = GameObject.Find("FrontPos");
        //    this.transform.parent = marisa.transform;
        //}
	}
	
	// Update is called once per frame
	void Update () {

        if (isCount)
        {
            count++;
            fcount = fcount + Time.deltaTime;
        }

        if (count <= 90)
        {
            maspaSize = maspaSize + 0.1f;
            transform.localScale = new Vector3(maspaSize, maspaSize, maspaSize);
            transform.Rotate(Vector3.forward * 2f);
        }

        if (fcount > 5/3.0f && isShot == true)
        {
            Instantiate(MasterSpark, this.transform.position, this.transform.rotation);
            isShot = false;
            isCount = false;
        }


	}
}
