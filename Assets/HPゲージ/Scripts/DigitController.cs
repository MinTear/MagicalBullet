using UnityEngine;
using System.Collections;

public class DigitController : MonoBehaviour {
	public int Number;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.SetFloat ("_CurrentColumn", Number);
	}
}
