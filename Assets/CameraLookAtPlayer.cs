/*
 * FileName: CameraLookAtPlayer.cs
 * Purpose: Lock camera directly above GameObject target
 * Date: 4/14/21                                        */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtPlayer : MonoBehaviour
{
    void Start()
    {
        cameraPosition.y = 60.0f;
    }
    public GameObject target;
    public GameObject playerCamera;
    public Vector3 cameraPosition;
    public float cameraY;
    public float scrollScale = 0.1f;

    void Update()
    {
        cameraPosition.x = target.transform.position.x;
        cameraPosition.z = target.transform.position.z;
        cameraPosition.y = UpdateCameraZoom(cameraPosition.y);
        playerCamera.transform.position = cameraPosition;
    }

    float UpdateCameraZoom(float currentYPos)
    {
        float delta = -Input.mouseScrollDelta.y;
        if (currentYPos + delta < 30.0f)
            return 30.0f;
        else if (currentYPos + delta > 60.0f)
            return 60.0f;
        else
            return currentYPos + (delta * scrollScale);
    }
}
