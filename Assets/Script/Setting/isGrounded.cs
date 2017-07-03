using UnityEngine;
using System.Collections;

public class isGrounded : MonoBehaviour
{

    public GameObject Explosion;
    public GameObject SmallExplosion;
    public GameObject Explosion_Chill;
    public GameObject Chill;
    GameObject destroytarget;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Effect") || col.gameObject.CompareTag("Enemy-Effect"))
        {
            /*Instantiate(Explosion);*/
            Instantiate(Explosion, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);

            if (GameObject.Find("RazerBeam(Clone)") != null)
            {

                Destroy(GameObject.Find("RazerBeam(Clone)"));

            }

            /* (GameObject.Find("MasterSpark(Clone)") != null)
            {
                Destroy(GameObject.Find("MasterSpark(Clone)"));
            }*/
        }

        if (col.gameObject.CompareTag("Snow_Effect"))
        {
            Instantiate(Explosion_Chill, new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y - 2, col.gameObject.transform.position.z), Chill.transform.rotation);
            Destroy(col.gameObject, 2f);
        }

        if (col.CompareTag("Cristal-Effect"))
        {
            Instantiate(Chill, new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y - 2, col.gameObject.transform.position.z), Chill.transform.rotation);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Star"))
        {
            Instantiate(SmallExplosion, col.gameObject.transform.position, Quaternion.identity);
        }

        if (col.gameObject.CompareTag("MasterSpark"))
        {
            Instantiate(Explosion, col.gameObject.transform.position, Quaternion.identity);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.name == "CoreOfLaser")
        {
            Debug.Log("Particle System is IllusionLaser.");
            SoundPlayer.Instance.PlaySE(SoundPlayer.Sounds.Explosion, 0.05f);
        }
    }

    void OnDestroy()
    {
        AllEnemyDestroyed.destroyedCount++;
    }

}
