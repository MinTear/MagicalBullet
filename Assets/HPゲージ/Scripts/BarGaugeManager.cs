using UnityEngine;
using System.Collections;

public class BarGaugeManager : MonoBehaviour {
	public float Percentage;

	public Color BarColor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		renderer.material.SetFloat ("_Percentage", Percentage);
		renderer.material.SetColor ("_BarColor", BarColor);
	}
}
