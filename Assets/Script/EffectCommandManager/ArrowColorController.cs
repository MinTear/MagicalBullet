using UnityEngine;
using System.Collections;

public class ArrowColorController : MonoBehaviour
{

    public Color[] ArrowColor = new Color[2];

    // Use this for initialization
    void Start()
    {
        ArrowColor[0] = this.renderer.material.color;
        ArrowColor[1] = Color.white;
    }

    // Update is called once per frame
    void Update()
    {


            ArrowColor[1].r = Random.value;
            ArrowColor[1].g = Random.value;
            ArrowColor[1].b = Random.value;
            this.renderer.material.SetColor("_Color", Color.Lerp(ArrowColor[0], ArrowColor[1], 0.25f));
            ArrowColor[0] = this.renderer.material.GetColor("_Color");
        
    }
}
