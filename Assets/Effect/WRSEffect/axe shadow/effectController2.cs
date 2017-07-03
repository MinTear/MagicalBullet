using UnityEngine;
using System.Collections;

public class effectController2 : MonoBehaviour
{

    int time = 60;
    int count5 = 0;
    bool swi = false;
    bool swi2 = true;

    public GameObject Slash;




    // Use this for initialization
    void Start()
    {

        count5 = time;
    }

    // Update is ccoualled once per frame
    void Update()
    {



        if (Input.GetKeyDown("k") )
        {
            if (count5 >= time)
            {
                count5 = 0;
                swi = true;
            }
        }

        if ((Input.GetKeyDown("j") && Input.GetKeyDown("k") && Input.GetKeyDown("l")))
        {
            swi = false;
            count5 = -40;
        }
        else
        {
            if ((Input.GetKeyDown("k") && Input.GetKeyDown("l")))
            {
                swi = false;
                count5 = 18;
            }
        }

        if (count5 == 36 && swi == true)
        {
            Instantiate(Slash, this.transform.position, this.transform.rotation);
            swi = false;
        }

        if (swi == false && swi2==true)
        {
            if (Input.GetKeyDown("j") )
            {
                count5 = -40;
                swi2 = false;
            }

            if (Input.GetKeyDown("l"))
            {
                count5 = 18;
                swi2 = false;
            }
        }

        if (count5 == time)
        {
            swi2 = true;
        }

        if(Input.GetKey("c"))
        {
            if(count5>=time-2)
            {
                count5 = time - 18;
            }

        }

        count5++;

    }
}
