using UnityEngine;
using System.Collections;

public class fallSnow : MonoBehaviour
{

    public GameObject Cristal;
    public GameObject MagicCircle;
    public GameObject Sword;
    GameObject destroyTarget;
    GameObject target;
    Vector3 shotPosition;


    public float speed = 1.0f;
    public float count = 0;
    bool shot = false;

    float count1 = 40;
    bool swi = false;
    bool swi2 = true;
    bool swi3 = true;
   
	// Use this for initialization
	void Start () {
        
        //Instantiate(Cristal, new Vector3(0, 4.7f, 1), Cristal.transform.rotation);
       
        
	}
	
	// Update is called once per frame
	void Update () {
        if (count1 >= 0 && (Input.GetKeyDown(KeyCode.L) || (Input.GetKeyDown(KeyCode.L) && (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.J)))))
        {
            shot = true;
        }

        if (shot && count1 >= 10)
        {
            swi = true;
            swi3 = false;
            if (count == 1)
            {
                shotPosition = this.transform.position;
                Instantiate(MagicCircle, shotPosition, this.transform.rotation);
            }


            if (count == 15)
			{
                Instantiate(Cristal, shotPosition , this.transform.rotation);
                shot = false;
                count = 0;
                swi = false;
                swi3 = true;
            }

           count++;
        }

        if (swi == false && swi2 == true)
        {
            if (Input.GetKeyDown("k"))
            {
                count1 = -100;
                swi2 = false;
            }

            if (Input.GetKeyDown("j"))
            {
                count1 = -80;
                swi2 = false;
            }
        }

        if (count1 == 20)
        {
            swi2 = true;
        }

        if (Input.GetKey("c"))
        {
            if (count1 >= 19 && swi3==true)
            {
                count1 = 8;
            }

        }
        
        count1++;
	}

 
    }

    
