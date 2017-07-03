using UnityEngine;
using System.Collections;

public class GaugeColorPart : MonoBehaviour {
	public Color GaugeColor=Color.green;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.SetColor ("_BarColor", GaugeColor);
	}
}
