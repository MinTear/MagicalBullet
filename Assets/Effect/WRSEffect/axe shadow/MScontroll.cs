using UnityEngine;
using System.Collections;

public class MScontroll : MonoBehaviour {

    public GameObject Slash;
    public GameObject Explosion;

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("MiniShadow") && !col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("Enemy") && !col.gameObject.CompareTag("SearchArea") && !col.gameObject.CompareTag("Guard"))
        {
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
	    transform.rigidbody.AddForce(transform.right * -15f, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {

        
	}
}
