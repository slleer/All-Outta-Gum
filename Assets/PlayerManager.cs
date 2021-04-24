using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform player;
    public Transform playerCamera;
    float angle;
    Vector3 cameraPosition;
    readonly float scrollScale = 2f;

    //starting y position = 70.0f
    void Start()
    {
        cameraPosition.y = 70.0f;
    }

    /* Rotate player Y towards mouse
     * Update camera transform to stay locked on player */ 
    void Update()
    {
        //rotate Y towards mouse
        //logic: arctan( mousePosition.y - verticalCenter, mousePosition.x - horizontalCenter)
        angle = Mathf.Atan2((Input.mousePosition.y - (Screen.height / 2)), Input.mousePosition.x - (Screen.width / 2)) * Mathf.Rad2Deg;
        angle += 270; //needed to make angle work with unity axis system
        player.eulerAngles = new Vector3(0, -angle * Time.timeScale, 0);

        //update camera transform
        cameraPosition.x = player.position.x;
        cameraPosition.z = player.position.z;
        cameraPosition.y = UpdateCameraZoom(cameraPosition.y);
        playerCamera.position = cameraPosition;
    }

    //lock camera y between 60.0f and 80.0f
    float UpdateCameraZoom(float currentYPos)
    {
        float delta = -Input.mouseScrollDelta.y;
        if (currentYPos + delta < 60.0f)
            return 60.0f;
        else if (currentYPos + delta > 80.0f)
            return 80.0f;
        else
            return currentYPos + (delta * scrollScale);
    }
}
