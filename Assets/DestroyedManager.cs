using UnityEngine;
using System.Collections;

public class DestroyedManager : MonoBehaviour {
    GameObject Bullet;
    bool shot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Bullet = GameObject.Find("Cylinder");

        if (Bullet != null)
        {
            shot = true;
        }

        if (shot)
        {
            if (Bullet == null)
            {
                Destroy(this.gameObject);
            }
        }
	}
}
