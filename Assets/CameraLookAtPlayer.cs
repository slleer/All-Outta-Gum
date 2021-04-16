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
        
    }
    public GameObject target;

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, 60, target.transform.position.z);
    }
}
