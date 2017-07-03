using UnityEngine;
using System.Collections;

public class MagicCircle_in_selecting : MonoBehaviour
{

    float selectednumber;
   
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selectednumber = CharacterSelecterOnSelecting.selecter;
        
        if (this.transform.position.z == 6.5)
        {
            if (selectednumber > 45 && selectednumber <= 315)
            {
                Destroy(this.gameObject);
            }
        }

        if (this.transform.position.x == 6.5)
        {
            if (!(selectednumber > 45 && selectednumber <= 135))
            {
                Destroy(this.gameObject);
            }
        }

        if (this.transform.position.z == -6.5)
        {
            if (!(selectednumber > 135 && selectednumber <= 225))
            {
                Destroy(this.gameObject);
            }
        }

        if (this.transform.position.x == -6.5f)
        {
            if (!(selectednumber > 225 && selectednumber <= 315))
            {
                Destroy(this.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(selectednumber);
        }
    }

   
}