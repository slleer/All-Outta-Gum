/*
 * FileName: RotateYTowardsMouse.cs
 * Purpose: Rotate Y axis of objects to face mouse
 * Date: 4/14/21                                        */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYTowardsMouse : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public GameObject player;
    public Vector2 screenCenter;
    public float angle;

    void Update()
    {
        angle = Mathf.Atan2((Input.mousePosition.y - (Screen.height / 2)), Input.mousePosition.x - (Screen.width / 2)) * Mathf.Rad2Deg;
        angle += 180; //needed to make angle work with unity axis system
        player.transform.eulerAngles = new Vector3(0, -angle * Time.timeScale, 0);
    }
}
