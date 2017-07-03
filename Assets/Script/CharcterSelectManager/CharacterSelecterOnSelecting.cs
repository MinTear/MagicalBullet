using UnityEngine;
using System.Collections;

public class CharacterSelecterOnSelecting : MonoBehaviour
{
    public GameObject camera;
    public GameObject[] Characters;
    public GameObject effect;
    public GameObject character;
    public static float selecter;
    bool inst = false;
    bool selectSwitch;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName == "CharacterSelection")
        {
            if (camera == null)
            {
                camera = GameObject.FindGameObjectWithTag("MainCamera");
            }

            else
            {
                selecter = camera.transform.eulerAngles.y;

                /*if ((selecter >= 0 && selecter <= 45) || (selecter > 315 && selecter <= 360))
                {
                    selectSwitch = true;

                    if (character == Characters[0])
                    {
                        selectSwitch = false;
                    }


                    character = Characters[0];

                    if (selectSwitch)
                    {
                        Instantiate(effect, new Vector3(0, 0, 6.5f), Quaternion.identity);
                    }
                }*/

                if ((selecter >= 0 && selecter <= 45) || (selecter > 315 && selecter <= 360))
                {
                    character = null;
                }

                if (selecter > 45 && selecter <= 135)
                {
                    selectSwitch = true;

                    if (character == Characters[0])
                    {
                        selectSwitch = false;
                    }

                    character = Characters[0];

                    if (selectSwitch)
                    {
						Instantiate(effect, new Vector3(6.5f, 0, 0), Quaternion.identity);
                    }
                }

                if (selecter > 135 && selecter <= 225)
                {
                    selectSwitch = true;

                    if (character == Characters[2])
                    {
                        selectSwitch = false;
                    }

                    character = Characters[2];
                    if (selectSwitch)
                    {
                        Instantiate(effect, new Vector3(0, 0, -6.5f), Quaternion.identity);
                    }
                }

                if (selecter > 225 && selecter <= 315)
                {
                    selectSwitch = true;

                    if (character == Characters[3])
                    {
                        selectSwitch = false;
                    }

                    character = Characters[3];

                    if (selectSwitch)
                    {
                        Instantiate(effect, new Vector3(-6.5f, 0, 0), Quaternion.identity);
                    }
                }
            }
        }

        if (Application.loadedLevelName == "MagicalFPS")
        {
            Instantiate(character, new Vector3(0f, 0f, 81.79605f), Quaternion.Euler(0, 180, 0));
            //Instantiate(Characters[4], new Vector3(0,0.75f,14),Quaternion.Euler(0,180,0));
            inst = true;
            
        }

    }

    void LateUpdate()
    {
        if (Application.loadedLevelName == "CharacterSelection")
        {
            if (Input.GetKeyDown(KeyCode.Space) && character != null)
            {
                StartGameBody();

            }
        }

        if (inst)
        {
            DestroyObject(this);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(selecter);
        }

    }

    public void StartGameBody()
    {
        SoundPlayer.Instance.PlaySE(SoundPlayer.Sounds.Decided);
        Application.LoadLevelAsync("MagicalFPS");
    }
}