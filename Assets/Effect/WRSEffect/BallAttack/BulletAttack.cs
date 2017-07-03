using UnityEngine;
using System.Collections;

public class BulletAttack : MonoBehaviour {

    int count1 =200;
    public GameObject Bullet;
    bool swi = false;
    bool swi2 = true;

    
    //void OnCollisionEnter()
    //{
    //    Destroy(Bullet);
    //}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        
        if (Input.GetKeyDown("j"))
        {
            
            if (count1 >= 200 )
            {
                swi = true;

                if (!(Input.GetKeyDown("j") && Input.GetKeyDown("k") && Input.GetKeyDown("l")))
                {
                    if ((Input.GetKeyDown("j") && Input.GetKeyDown("k")))
                    {
                        swi = false;
                        count1 = 140;
                    }
                }

                if (swi == true)
                {
                    Instantiate(Bullet, this.transform.position, this.transform.rotation);
                    count1 = 80;
                    swi = false;
                }
            }
        }


        if (swi == false && swi2 == true)
        {
            if (Input.GetKeyDown("l") )
            {
                count1 = 158;
                swi2 = false;
            }

            if (Input.GetKeyDown("k"))
            {
                count1 = 140;
                swi2 = false;
            }
        }

        if (count1 == 200)
        {
            swi2 = true;
        }

        if (Input.GetKey("c"))
        {
            if (count1 >= 198)
            {
                count1 = 182;
            }

        }

        count1++;
	}
}
