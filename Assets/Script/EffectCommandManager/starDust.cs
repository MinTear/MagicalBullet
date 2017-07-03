using UnityEngine;
using System.Collections;

public class StarDust : MonoBehaviour
{

    public GameObject[] Star;
    public GameObject Mahoujin;
    public int j;
    private float x, y, z;
    private int count = 0;

    // Use this for initialization
    void Start()
    {
        Instantiate(Mahoujin);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (++count >= 60)
        {
            for (int i = 0; i < j; i++)
            {
                x = Random.Range(-100f, 100f);
                y = Random.Range(100f, 150f); ;
                z = Random.Range(-100f, 100f);
                Instantiate(Star[i], new Vector3(x, y, z), Quaternion.identity);
            }
        }
    }
}
