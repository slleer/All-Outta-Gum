﻿/*
 * FileName: PlayerMovement.cs
 * Purpose: Implement player movement using WASD + Shift
 * Date: 4/14/21                                        */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Start()
    {
        
    }

    public float deltaPosition = 10.0f;
    public float jumpHeight = 5.0f;
    public float sprintMultiplier = 1.5f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(deltaPosition * sprintMultiplier * Vector3.forward * Time.deltaTime);
            if (Input.GetKey(KeyCode.S))
                transform.Translate(deltaPosition * sprintMultiplier * Vector3.back * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                transform.Translate(deltaPosition * sprintMultiplier * Vector3.left * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                transform.Translate(deltaPosition * sprintMultiplier * Vector3.right * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(deltaPosition * Vector3.forward * Time.deltaTime);
            if (Input.GetKey(KeyCode.S))
                transform.Translate(deltaPosition * Vector3.back * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                transform.Translate(deltaPosition * Vector3.left * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                transform.Translate(deltaPosition * Vector3.right * Time.deltaTime);
        } 
    }
}
