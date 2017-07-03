using UnityEngine;
using System.Collections;

public class WRSAnimatorControll : MonoBehaviour
{

    int count=200;
    int count2=42;
    int count3=60;
    bool swi1 = false;
    bool swi2 = false;
    bool swi3 = false;


    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("c"))
        {
            animator.SetBool("Guard", true);

            if (count >= 198)
            {
                count = 182;
            }

            if (count2 >= 40)
            {
                count2 = 24;
            }

            if (count3 >= 58)
            {
                count3 = 42;
            }
        }
        else
        {
            animator.SetBool("Guard", false);
        }

        if(Input.GetKeyDown("j") && Input.GetKeyDown("k") && Input.GetKeyDown("l"))
        {
            swi1=true;
        }
        else
        {
            if(Input.GetKeyDown("j") && Input.GetKeyDown("l"))
            {
                swi1=true;
            }

            if(Input.GetKeyDown("j") && Input.GetKeyDown("k"))
            {
                swi2=true;
            }

            if(Input.GetKeyDown("k") && Input.GetKeyDown("l"))
            {
                swi3=true;
            }

        }

        if (count >= 200)
        {
            if ((swi2==false && Input.GetKeyDown("j")) || swi1==true )
            {
                count2 = -38;
                count3 = -20;
                animator.SetBool("BallAttack", true);
                count = 120;
            }
        }

        if (count > 194)
        { 
            animator.SetBool("BallAttack", false);
        }

        if (count2 >= 42)
        {
            if (Input.GetKeyDown("l") || swi3==true)
            {
                count=158;
                count3 = 18;
                animator.SetBool("MiniShadow", true);
                count2 = 0;
                
            }
        }

        if(count2 > 36)
        {
            animator.SetBool("MiniShadow", false);
        }

        if (count3 >= 60)
        {
            if (Input.GetKeyDown("k") || swi2==true)
            {
                count = 140;
                count2 = -18;
                animator.SetBool("AxeShadow", true);
                count3 = 0;
                
            }
        }
       
        if (count3 > 54)
        { 
            animator.SetBool("AxeShadow", false);
        }

        if(swi1==true || swi2==true || swi3==true)
        {
            swi1 = false;
            swi2 = false;
            swi3 = false;
        }

        count++;
        count2++;
        count3++;
    }
}
