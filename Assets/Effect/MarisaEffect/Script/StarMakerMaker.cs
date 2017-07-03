using UnityEngine;
using System.Collections;

public class StarMakerMaker : MonoBehaviour
{

    public GameObject StarMaker;
    public Transform Left;
    public Transform Right;

    public float R = 1f;
    private static bool existStar = false;

    public static bool ExistStar { get { return StarMakerMaker.existStar; } }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!existStar && Input.GetKeyDown(KeyCode.K) && !Input.GetKeyDown(KeyCode.J) && !Input.GetKeyDown(KeyCode.L) &&
            !MasterSparkMakerMaker.ExistLaser)
        {
            Instantiate(StarMaker, this.transform.position, this.transform.rotation);

            Vector3 up, down;
            up = down = this.transform.position;
            up.y += R;
            down.y -= R;
            Instantiate(StarMaker, up, this.transform.rotation);
            Instantiate(StarMaker, down, this.transform.rotation);

            Instantiate(StarMaker, Left.position, this.transform.rotation);
            Instantiate(StarMaker, Right.position, this.transform.rotation);

            existStar = true;
        }

        if (existStar && !GameObject.Find("StarMaker(Clone)"))
        {
            existStar = false;
        }
    }
}
