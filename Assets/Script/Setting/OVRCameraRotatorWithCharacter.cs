using UnityEngine;
using System.Collections;

public class OVRCameraRotatorWithCharacter : MonoBehaviour
{
    public Transform cameraPosition;
    GameObject selectedCharacter;
    bool runSwitch = true;
    Vector3 cameraPosition_back;

    // Use this for initialization
    void Start()
    {
        cameraPosition_back = new Vector3(0, 0, -2);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void LateUpdate()
    {
        if (Application.loadedLevelName == "MagicalFPS" && selectedCharacter == null)
        {
            selectedCharacter = GameObject.FindGameObjectWithTag("Player");
        }

        if (Application.loadedLevelName == "MagicalFPS" && selectedCharacter != null)
        {
            
           selectedCharacter.transform.rotation = cameraPosition.rotation;
        }
    }
}