using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour
{
    public GameObject Explosion;
    public float i;
    public float speed;

    // Use this for initialization
    void Start()
    {
        transform.rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * i);
        transform.Rotate(Vector3.up * i);
        transform.Rotate(Vector3.forward * i);
    }

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Circle") && !col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("SearchArea"))
        {
            //Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {

    }
}

