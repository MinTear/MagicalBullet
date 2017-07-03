using UnityEngine;
using System.Collections;

public class CristalMovemntController : MonoBehaviour {

    public float i;
    public float speed;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rigidbody.AddForce(transform.forward * 1f, ForceMode.VelocityChange);
    }
}
