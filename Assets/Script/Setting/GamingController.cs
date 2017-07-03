using UnityEngine;
using System.Collections;

public class GamingController : MonoBehaviour {

    public static bool end = false;
    bool gameOver = false;
    bool pause = false;
    bool stop = false;
    GameObject Player;
    string sceneName;
    float resetTime = 0;
    int resetcount = 10;
    float time;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () {
        sceneName = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {

        if (Application.loadedLevelName == "Title")
        {
            AllEnemyDestroyed.destroyedCount = 0;
            end = false;
            PlayerDamageManager.HP = 1.0f;
            if (Input.anyKeyDown)
            {
                SoundPlayer.Instance.PlaySE(SoundPlayer.Sounds.Decided);
                Application.LoadLevelAsync("CharacterSelection");
            }
        }


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //if (Input.GetKeyDown(KeyCode.RightShift) && Input.GetKeyDown(KeyCode.KeypadEnter))
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            pause = !pause;
        }

        if (GameObject.FindGameObjectWithTag("Effect") != null && Application.loadedLevelName == "MagicalFPS")
        {
            stop = true;
        }

        pauseManager(pause);

        if (Application.loadedLevelName == "GameEnd" || Application.loadedLevelName == "GameOver")
        {//ゲーム終了時の場合
            
            Player = null;
            resetTime += Time.deltaTime;

            if (resetTime >= resetcount)
            {
                Application.LoadLevelAsync("Title");
                AllEnemyDestroyed.destroyedCount = 0;
                Destroy(this.gameObject);
                //resetTime = 0;
            }
        }

        if (end  && Application.loadedLevelName == "MagicalFPS")
        {
            Time.timeScale = 0.3f;
            resetTime += Time.deltaTime;

            if (end && resetTime >= 1.5f)
            {
                Application.LoadLevelAsync("GameEnd");
                end = false;
                resetTime = 0;
            }
        }


        if (PlayerDamageManager.HP <= 0)
        {
            gameOver = true;
        }

        if (gameOver)
        {
            Time.timeScale = 0.3f;
            time += Time.deltaTime;

            if (time >= 1.5f)
            {
                gameOver = false;
                end = false;
                PlayerDamageManager.HP = 1.0f;
                Application.LoadLevelAsync("GameOver");
                time = 0;
                resetTime = 0;
            }
        }

	}

    void LateUpdate()
    {
        if (Application.loadedLevelName == "MagicalFPS" && Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Player.GetComponent<Rigidbody>();
        }

		if(pause && Application.loadedLevelName == "MagicalFPS")
		{
            Player.rigidbody.velocity = Vector3.zero;
            Player.rigidbody.angularVelocity = Vector3.zero;
            

		}
    }

      void pauseManager(bool paused)
    {
        if (paused)
        {
            Time.timeScale = 0;
            
        }

        if (!paused)
        {
            Time.timeScale = 1;
            
        }
    }


}
