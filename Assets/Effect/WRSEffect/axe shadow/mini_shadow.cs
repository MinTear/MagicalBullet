﻿using UnityEngine;
using System.Collections;

public class mini_shadow : MonoBehaviour
{

    int time = 42;
    int count = 0;
    public GameObject Slash;
    bool swi = false;
    bool swi2 = true;
    
    

    // Use this for initialization
    void Start()
    {
        count = time;
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown("l") )
        {
            if (count >= time)
            {
                count = 0;
                swi=true;
            }
        }
        
        if((Input.GetKeyDown("j") && Input.GetKeyDown("l")))
        {
            swi = false;
            count = -58;
        }

        if (count == 8 && swi==true)
        {
            Instantiate(Slash, this.transform.position, this.transform.rotation);
            swi = false;
        }


        if (swi == false && swi2 == true)
        {
            if (Input.GetKeyDown("j") )
            {
                count = -58;
                swi2 = false;
            }

            if (Input.GetKeyDown("k"))
            {
                count = -18;
                swi2 = false;
            }
        }

        if (count == time)
        {
            swi2 = true;
        }

        if (Input.GetKey("c"))
        {
            if (count >= time - 2)
            {
                count = time - 18;
            }

        }

         count++;
    }
}

