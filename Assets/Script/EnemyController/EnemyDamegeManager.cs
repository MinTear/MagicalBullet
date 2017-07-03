using UnityEngine;
using System.Collections;

public class EnemyDamegeManager : MonoBehaviour
{
    public float Enemy_HP;
    public string[] effectTag;
    public GameObject Explosion;
    public GameObject Snow_Explosion;
    public GameObject SmallExplosion;
    public GameObject Chill_Explosion;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Enemy_HP <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(Explosion, this.transform.position, this.transform.rotation);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        tagTrigger(col, "Effect", 0.7f, Explosion);
        tagTrigger(col, "Snow_Effect", 0.3f, Chill_Explosion, 1f);
        tagTrigger(col, "MasterSpark", 1f, Explosion);
        tagTrigger(col, "Star", 0.1F, SmallExplosion);
        tagTrigger(col, "AxeShadow", 0.5f, SmallExplosion);
        tagTrigger(col, "MiniShadow", 0.16f, SmallExplosion);
        tagTrigger(col, "BallAttack", 0.8f, SmallExplosion);
        tagTrigger(col, "Cristal-Effect", 0.2f, Snow_Explosion);

    }

    void OnParticleCollision(GameObject other)
    {
        ParticleChecker(other, "CoreOfLaser", 0.4f);
        
    }

    void tagTrigger(Collider col, string str, float damegePoint, GameObject damegeEffect)
    {
        if (col.gameObject.CompareTag(str))
        {
            Enemy_HP -= damegePoint;
            Instantiate(damegeEffect, col.gameObject.transform.position, col.transform.rotation);

            Destroy(col.gameObject);

            if (GameObject.FindGameObjectWithTag(str))
            {
                Destroy(GameObject.FindGameObjectWithTag(str));
            }

        }
    }

    void tagTrigger(Collider col, string str, float damegePoint, GameObject damegeEffect,float time)
    {
        if (col.gameObject.CompareTag(str))
        {
            Enemy_HP -= damegePoint;
            Instantiate(damegeEffect, col.gameObject.transform.position, col.transform.rotation);

            Destroy(col.gameObject, time);

        }
    }

    //以下、魔理沙の一部の技用に追加。

    void ParticleChecker(GameObject other, string str, float damegePoint)
    {
        if (other.name == str)
        {
            Enemy_HP -= damegePoint;
            SoundPlayer.Instance.PlaySE(SoundPlayer.Sounds.Explosion, 0.05f);
        }
    }

    /*
    void tagTrigger(Collider col, string str, float damegePoint)
    {
        if (col.gameObject.CompareTag(str))
        {
            Enemy_HP -= damegePoint;

            if (GameObject.FindGameObjectWithTag(str))
            {
                Destroy(GameObject.FindGameObjectWithTag(str));
            }
        }
    }
    */
}
