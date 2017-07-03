using UnityEngine;
using System.Collections;

public class StarMaker : MonoBehaviour
{

    public GameObject Star;
    private int count = 0;

    // Use this for initialization
    void Start()
    {
        Instantiate(Star, this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
