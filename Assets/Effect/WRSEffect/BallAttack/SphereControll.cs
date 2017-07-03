using UnityEngine;
using System.Collections;

public class SphereControll : MonoBehaviour {

    int count;
    float size = 19.6f;
    public GameObject Bullet;
    int i = 20;
    public AudioClip sound01;
    public GameObject Explosion;

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("MiniShadow") && !col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("Enemy") && !col.gameObject.CompareTag("SearchArea"))
        {
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    

    //void OnCollisionEnter()
    //{
    //    Destroy(Bullet);
    //}

	// Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (count > 80)
        {
            transform.rigidbody.AddForce(transform.forward * 1, ForceMode.Impulse);
            //transform.Rotate(Vector3.right * i);
            //transform.Rotate(Vector3.up * i);
            transform.Rotate(Vector3.forward * i);
            audio.PlayOneShot(sound01, 0.4f);
        }
        

        if (count <= 80)
        {
            transform.localScale = new
              Vector3(count/size, count/size, count/size);
            transform.Rotate(4.535f, 0,0);
            
        }
        

        count++;

	}
}
