using UnityEngine;
using System.Collections;

public class EnemyAreaController : MonoBehaviour {
    float summonTime = 0;
    bool summon;
    public GameObject Enemy;
    public GameObject EnemyArea1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (summonTime <= 10)
        {
            summonTime += Time.deltaTime;

            if (summonTime >= 8)
            {
                summon = true;
            }
        }

        if (summon)
        {
            Instantiate(Enemy, EnemyArea1.transform.position, EnemyArea1.transform.rotation);
            summon = false;
            summonTime = 12;
        }
	}
}
