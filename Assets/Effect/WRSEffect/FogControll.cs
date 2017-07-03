using UnityEngine;
using System.Collections;

public class FogControll : MonoBehaviour {

    int count = 200;
    bool swi = true;
    float size = 0f;
    int count4 = 0;
    public GameObject Fog;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("c") && count >= 200 && (count4 <= 650 || count4 >= 780))
        {
            
            count4++;
            size = count4 + 50.0f;
            transform.localScale = new
              Vector3(50 / size, 50 / size, 50 / size);

        }
        else
        {
            if (count4 >= 0)
            {
                count4--;
            }
        }

        if (size >= 650)
        {

        }

        if (size >= 780)
        {
            size = 50;
            count4 = 0;
        }

        if (swi == true)
        {
            if (Input.GetKeyDown("j"))
            {
                count = 0;
                swi = false;
            }
            else if (Input.GetKeyDown("k"))
            {
                count = 140;
                swi = false;
            }
            else if (Input.GetKeyDown("l"))
            {
                count = 158;
                swi = false;
            }
        }

        if (count >= 200)
        {
            swi = true;
        }

        count++;
	}
}
