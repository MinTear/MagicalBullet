using UnityEngine;
using System.Collections;

public class ShotOperator : MonoBehaviour {
    public GameObject RazerBeam;
    public GameObject magicCircuit1,magicCircuit2;
    public Transform[] SteckPos;
    Vector3[] spellPos = new Vector3[2];
    Quaternion rotatePos;

    float count = 0;

    bool shot = false;

    float count1 = 200;
    bool swi = false;
    bool swi2 = true;
    bool swi3 = true;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (!shot)
        {
            if (count1 >= 95 && (Input.GetKeyDown(KeyCode.J) && !Input.GetKeyDown(KeyCode.L)))
            {
                
                for (int i = 0; i < 2; i++)
                {
                    spellPos[i] = SteckPos[i].position;
                }

                shot = true;
            }

        }

        if (shot && count1 >= 100)
        {
            swi = true;
            swi3 = false;
            if (count == 1)
            {
                
                rotatePos = this.transform.rotation;

                Instantiate(magicCircuit1, spellPos[0], rotatePos);
            }

            if (count == 30)
            {
     
                Instantiate(magicCircuit2, spellPos[1], rotatePos);
            }
            
            if (count == 90)
            {
                Instantiate(RazerBeam, spellPos[1], rotatePos);
            }

            if (count >= 100) 
            { 
                if(GameObject.Find("RazerBeam(Clone)") == null){
                    shot = false;
                    count = 0;
                    swi = false;
                    swi3 = true;
                }
            }


            count++;
        }

        if (swi == false && swi2 == true)
        {
            if (Input.GetKeyDown("k"))
            {
                count1 = -35;
                swi2 = false;
            }

            if (Input.GetKeyDown("l"))
            {
                count1 = 80;
                swi2 = false;
            }
        }

        if (count1 == 100)
        {
            swi2 = true;
        }

        if (Input.GetKey("c") && swi3 == true)
        {
            if (count1 >= 99)
            {
                count1 = 91;
            }

        }
        count1++;
	}
}
