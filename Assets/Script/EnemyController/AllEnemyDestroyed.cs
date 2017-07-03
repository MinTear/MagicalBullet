using UnityEngine;
using System.Collections;

public class AllEnemyDestroyed : MonoBehaviour {
    public static float destroyedCount = 0;
    public float AchieveLevel;
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(destroyedCount);
        }
       
	}

    void OnDestroy()
    {
        if (destroyedCount < 4)
        {
            destroyedCount += AchieveLevel;
        }
        if (destroyedCount >= 4 && PlayerDamageManager.HP > 0)
        {
            GamingController.end = true;
        }
    }
}
