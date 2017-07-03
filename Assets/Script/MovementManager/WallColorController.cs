using UnityEngine;
using System.Collections;

public class WallColorController : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        this.renderer.material.SetColor("_Color", Color.white);
    }

    // Update is called once per frame
    void Update()
    {
        ColorController();
    }

    void ColorController()
    {
        int count = 0;
        if (Character_WallDestroyManager.skill_J)
        {
            count++;
        }
        if (Character_WallDestroyManager.skill_K)
        {
            count++;
        }
        if (Character_WallDestroyManager.skill_L)
        {
            count++;
        }

        if (count == 1)
        {
            this.renderer.material.SetColor("_Color", Color.green);
        }
        else if (count == 2)
        {
            this.renderer.material.SetColor("_Color", Color.yellow);
        }
        else if (count == 3)
        {
            this.renderer.material.SetColor("_Color", Color.magenta);
        }

    }
}
