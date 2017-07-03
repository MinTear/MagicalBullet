using UnityEngine;
using System.Collections;

public class MeteortrailMaker : MonoBehaviour
{

    public GameObject Meteortrail;
    public sbyte count = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

       
        
        Instantiate(Meteortrail, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        
        if (count >= 120)
        {
            count = 0;
        }
    }
}
