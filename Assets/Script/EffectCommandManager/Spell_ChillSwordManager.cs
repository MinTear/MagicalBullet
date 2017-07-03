using UnityEngine;
using System.Collections;

public class Spell_ChillSwordManager : MonoBehaviour {

    public GameObject Chill;
    public GameObject spellCircuit;
    public Transform[] chillPosition;

    Vector3[] spellPosition = new Vector3[3];
    Vector3[] callingPosition = new Vector3[3];
   
    float count = 0;
    float count2 = 0;
    bool shot = false;

    float count1 = 270;
    bool swi = false;
    bool swi2 = true;
    bool swi3 = true;

	// Use this for initialization
	void Start () {
        Chill.transform.transform.localScale = new Vector3(157, 150, 240);
    }
	
	// Update is called once per frame
	void Update () {

        if (count2 >= 0 && (Input.GetKeyDown(KeyCode.K) && !Input.GetKeyDown(KeyCode.L)))
        {
            shot = true;
        }

        if (shot && count1 >= 120)
        {
            swi = true;
            swi3 = false;
            if (count == 1)
            {

                for (int i = 0; i < 3; i++)
                {
                    spellPosition[i] = chillPosition[i].position;
                    callingPosition[i] = chillPosition[i].position;

                }

                    Instantiate(spellCircuit, spellPosition[0] + new Vector3(0,3.2f,0), Quaternion.identity);
            }

            if (count == 15)
            {
                Instantiate(spellCircuit, spellPosition[1] + new Vector3(0,3.2f,0) , Quaternion.identity);
            }

            if (count == 30)
            {
                Instantiate(spellCircuit, spellPosition[2] + new Vector3(0,3.2f,0) , Quaternion.identity);
            }


            if (count == 60)
            {
               
                Instantiate(Chill, callingPosition[0] + new Vector3(0,1.4f,0), Chill.transform.rotation);

            }

            if (count == 75)
            {
                
                Instantiate(Chill, callingPosition[1] + new Vector3(0, 1.4f, 0), Chill.transform.rotation);
            }

            if (count == 90)
            {
               
                Instantiate(Chill, callingPosition[2] + new Vector3(0, 1.4f, 0), Chill.transform.rotation);
            }

            if (count >= 120)
            {
                count = 0;
                shot = false;
                swi = false;
                swi3 = true;
            }

            count ++;
        }

        if (swi == false && swi2 == true)
        {
            if (Input.GetKeyDown("j"))
            {
                count1 = 35;
                swi2 = false;
            }

            if (Input.GetKeyDown("l"))
            {
                count1 = 120;
                swi2 = false;
            }
        }

        if (count1 == 135)
        {
            swi2 = true;
        }

        if (Input.GetKey("c"))
        {
            if (count1 >= 134 && swi3 == true)
            {
                count1 = 126;
            }

        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            count2 = -100;
        }

        count2++;
        count1++;
	}
}
