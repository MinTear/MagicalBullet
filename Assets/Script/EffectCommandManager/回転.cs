using UnityEngine;
using System.Collections;

public class 回転 : MonoBehaviour
{

    public float i;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * i);
        transform.Rotate(Vector3.up * i);
        transform.Rotate(Vector3.forward * i);
    }
}
