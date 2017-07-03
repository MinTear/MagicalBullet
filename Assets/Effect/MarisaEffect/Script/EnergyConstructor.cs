using UnityEngine;
using System.Collections;

public class EnergyConstructor : MonoBehaviour
{

    public float speed;
    public float size = 0f;
    public float i = 1f;
    public bool isCharge;
    public bool isShot;

    // Use this for initialization
    void Start()
    {
        isCharge = true;
        isShot = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Period) && isCharge)
        {
            size = size + i;
            transform.localScale = new Vector3(size, size, size);
            isShot = true;
        }

        if (!Input.GetKey(KeyCode.Period) && isShot)
        {
            float x = Random.Range(0f, 0f);
            float y = Random.Range(0f, 0f); ;
            float z = Random.Range(speed, speed);
            transform.rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
            isShot = false;
            isCharge = false;
        }

        if (!isCharge && !isShot)
        {
            transform.Rotate(Vector3.right * 5);
            transform.Rotate(Vector3.up * 5);
            transform.Rotate(Vector3.forward * 5);
        }
    }

    void LateUpdate()
    {

    }
}

