using UnityEngine;
using System.Collections;

public class MasterSparkController : MonoBehaviour
{
    public GameObject Explosion;
    public float fowardSpeed = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Translate(Vector3.up * Time.deltaTime * fowardSpeed);
	}
    
    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Circle") && !col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("SearchArea"))
        {
            //Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
