using UnityEngine;
using System.Collections;

public class IllusionLaserColorController : MonoBehaviour
{

    public Color IllusionLaserColor = Color.yellow;
    bool isClear = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
    {
        ColorController();
	}

    void LateUpdate()
    {

    }

    void ColorController()
    {
        if (IllusionLaserColor.a >= 1f)
        {
            isClear = false;
        }
        else if (IllusionLaserColor.a <= 0f)
        {
            isClear = true;
        }

        if (isClear == true)
        {
            IllusionLaserColor.a += 0.005f;
        }
        else
        {
            IllusionLaserColor.a -= 0.005f;
        }

        this.renderer.material.SetColor("_TintColor", IllusionLaserColor);
    }


}
