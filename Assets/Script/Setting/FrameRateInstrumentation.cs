using UnityEngine;
using System.Collections;

public class FrameRateInstrumentation : MonoBehaviour
{
    private float oldTime;
    private int frame = 0;
    private float frameRate = 0f;
    private const float INTERVAL = 0.5f; // この時間おきにFPSを計算して表示させる

    private void Start()
    {
        oldTime = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        frame++;
        float time = Time.realtimeSinceStartup - oldTime;
        if (time >= INTERVAL)
        {
            // この時点でtime秒あたりのframe数が分かる
            // time秒を1秒あたりに変換したいので、frame数からtimeを割る
            frameRate = frame / time;
            guiText.text = frameRate.ToString(); // GUITextとして表示
            oldTime = Time.realtimeSinceStartup;
            frame = 0;
        }
    }
}