using UnityEngine;
using System.Collections;

public class PlayerDamageManager : MonoBehaviour
{

    private static float hP = 1;
    public float DamageRate;
    static int debugModeCount = 0;
    public static float HP
    {
        set { if (debugModeCount < 3) { PlayerDamageManager.hP = value; } }
        get { return PlayerDamageManager.hP; }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DebugMode();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy-Effect") && debugModeCount < 3)
        {
            hP -= 1.0f / DamageRate;
        }
    }

    void DebugMode()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            debugModeCount++;
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            debugModeCount = 0;
            Debug.Log("DebugMode = false;");
        }

        if (debugModeCount == 3)
        {
            Debug.Log("もう貴方のHPは減りません。やったぜ。");
            debugModeCount++;
        }
    }
}
