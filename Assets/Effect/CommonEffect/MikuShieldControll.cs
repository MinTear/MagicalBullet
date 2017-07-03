using UnityEngine;
using System.Collections;

public class MikuShieldControll : MonoBehaviour {

    public GameObject Shield;
    int count = 200;
    bool swi = true;
    bool swi2 = false;
    GameObject destroyTarget;
    int count2 = 0;
    int count3 = 0;
    GameObject BeamDestroy;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy-Effect"))
        {
            BeamDestroy = GameObject.FindGameObjectWithTag("Enemy-Effect");
            Destroy(BeamDestroy);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("c") && count >= 200)
        {
            Instantiate(Shield, this.transform.position, this.transform.rotation);
            count2++;
            swi2 = true;
            count3 = 0;


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
                count = -30;
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


        if (count2 == 4)
        {
            destroyTarget = GameObject.FindGameObjectWithTag("Guard");
            Destroy(destroyTarget);
            count2 = 3;
            swi2 = false;
        }

        if (count3 < 4)
        {
            if (count3 != 0)
            {
                destroyTarget = GameObject.FindGameObjectWithTag("Guard");
                Destroy(destroyTarget);
                count2 = 0;
            }
        }
        count++;
        count3++;

    }
}
