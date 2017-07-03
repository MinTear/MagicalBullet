using UnityEngine;
using System.Collections;

public class GaugeController : MonoBehaviour {
	public float Hp;
	public Color InitialColor=Color.blue;
	public Color FinalColor=Color.red;

	private GaugeColorPart[] ColorParts;
	private TextGaugeController GaugeTextController;
	private BarGaugeManager BarManager;
	// Use this for initialization
	void Start () {
		ColorParts=gameObject.GetComponentsInChildren<GaugeColorPart> ();
		GaugeTextController = gameObject.GetComponentInChildren<TextGaugeController> ();
		BarManager = gameObject.GetComponentInChildren<BarGaugeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
       // Hp = PlayerDamageManager.HP * 100;
		Color gaugeColor=Color.Lerp(InitialColor,FinalColor,1-Hp/99.9f);
		foreach (var item in ColorParts) {
			item.GaugeColor=gaugeColor;
		}
		GaugeTextController.Hp = Hp;
		BarManager.Percentage = Hp / 99.9f;
		BarManager.BarColor = gaugeColor;
	}
}
