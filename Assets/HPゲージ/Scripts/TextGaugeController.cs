using UnityEngine;
using System.Collections;

public class TextGaugeController : MonoBehaviour {
	public float Hp;

	public DigitController FirstDigit;
	public DigitController SecoundDigit;
	public DigitController FracDigit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Hp = Mathf.Min (99.9f, this.Hp);
		Hp = Mathf.Max (0.0f, this.Hp);
		FirstDigit.Number =(int)( Hp / 10.0f);
		float HpCache = Hp - FirstDigit.Number * 10;
		SecoundDigit.Number = (int)HpCache;
		HpCache=HpCache-SecoundDigit.Number;
		FracDigit.Number = (int)(HpCache * 10);
	}
}
