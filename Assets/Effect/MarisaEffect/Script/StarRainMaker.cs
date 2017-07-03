using UnityEngine;
using System.Collections;

public class StarRainMaker : MonoBehaviour
{

    int count = 0;
    float magicCircleSize = 0;
    bool isCount = true;
    bool isShot = true;
    public GameObject StarRain;
    Color magicCircleColor = Color.white;
    Vector3 CreateRainPos;

	// Use this for initialization
    void Start()
    {
        
	}
	
	// Update is called once per frame
	void Update () {

        ColorController();

        if (isCount)
        {
            count++;
        }

        if (count < 45)
        {
            magicCircleSize = magicCircleSize + 0.2f;
            transform.localScale = new Vector3(magicCircleSize, magicCircleSize, magicCircleSize);
            transform.Rotate(Vector3.forward * 4f);
        }

        if (count > 50 && isShot == true)
        {
            CreateRainPos = this.transform.position;
            CreateRainPos.y -= 5f;
            Instantiate(StarRain, CreateRainPos, this.transform.rotation);
            isShot = false;
            isCount = false;
        }
	
	}

    void ColorController()
    {
        if (magicCircleColor.a >= 0.0f)
        {
            magicCircleColor.a -= 1f / 300f;
        }


        this.renderer.material.SetColor("_TintColor", magicCircleColor);
    }
}
