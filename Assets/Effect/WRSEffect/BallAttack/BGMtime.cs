using UnityEngine;
using System.Collections;

public class BGMtime : MonoBehaviour {

    float count = 0;
    public AudioClip bgm;
    float time = 60.0f;
    int count2 = 0;
    bool on = true;

    

	// Use this for initialization
	void Start () {
        audio.time=37.4f;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (count2 == 70 )
        {
            audio.Stop();
            on = true;
        }
        if (on == true)
        {
            if (count2 == 71)
            {

                audio.PlayOneShot(bgm, 0.6f);
                on = false;
                count = -35;
            }
        }

        count+=Time.deltaTime;
        count2 = (int)count;
        
    }

}
