using UnityEngine;
using System.Collections;

public class RazerBeamDestoryManager : MonoBehaviour {
    GameObject[] Beam;

	// Use this for initialization
	void Start () {
        Beam = GameObject.FindGameObjectsWithTag("Enemy-Effect");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        foreach (GameObject target in Beam)
        {
            Destroy(target);
        }
    }
}
