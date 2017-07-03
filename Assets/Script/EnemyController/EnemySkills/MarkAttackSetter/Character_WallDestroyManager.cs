using UnityEngine;
using System.Collections;

public class Character_WallDestroyManager : MonoBehaviour {

    public string[] SkillName;
    public static bool skill_J = false, skill_K = false, skill_L = false;
    public GameObject Explosion;
    bool destroy = false;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (skill_J && skill_K && skill_L)
        {
            Destroy(this.gameObject,0.5f);
            destroy = true;
            skill_J = false;
            skill_K = false;
            skill_L = false;
            
        }

        if (destroy)
        {
            Instantiate(Explosion, this.transform.position, this.transform.rotation);
            destroy = false;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag(SkillName[0]))
        {
            skill_J = true;
        }

        if (col.gameObject.CompareTag(SkillName[1]))
        {
            skill_K = true;
        }

        if (col.gameObject.CompareTag(SkillName[2]))
        {
            skill_L = true;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.name == "CoreOfLaser")
        {
            skill_L = true;
        }
    }
}
