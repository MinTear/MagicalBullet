using UnityEngine;
using System.Collections;

public class PalyerDamagedBehavior : MonoBehaviour {

    public GameObject DamageLight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy-Effect") )
        {
            Instantiate(DamageLight, col.transform.position, col.transform.rotation);
            Destroy(col.gameObject);
			Debug.Log("Damage");
        }
    }


}
