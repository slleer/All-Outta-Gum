/*
 * FileName: RotateYTowardsMouse.cs
 * Purpose: Rotate Y axis of objects to face mouse
 * Date: 4/14/21                                        */

using UnityEngine;

public class RotateYTowardsMouse : MonoBehaviour
{

    //public GameObject player;
    public Transform player;
    float angle;

    void Update()
    {
        //logic: arctan( mousePosition.y - verticalCenter, mousePosition.x - horizontalCenter
        angle = Mathf.Atan2((Input.mousePosition.y - (Screen.height / 2)), Input.mousePosition.x - (Screen.width / 2)) * Mathf.Rad2Deg;
        angle += 270; //needed to make angle work with unity axis system
        player.eulerAngles = new Vector3(0, -angle * Time.timeScale, 0);
    }
}
