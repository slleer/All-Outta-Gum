using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYTowardsMouse : MonoBehaviour
{
    //public Vector2 screenDimensions;
    public Vector2 screenCenter;
    // Start is called before the first frame update
    void Start()
    {
        
    }    

    //public Vector2 mousePosition;
    public float angle;

    // Update is called once per frame
    void Update()
    {
        //screenDimensions.x = Screen.width;
        //screenDimensions.y = Screen.height;
        //screenCenter.x = screenDimensions.x / 2;
        //screenCenter.y = screenDimensions.y / 2;
        //screenCenter.x = Screen.width / 2;
        //screenCenter.y = Screen.height / 2;
        //mousePosition.x = Input.mousePosition.x;
        //mousePosition.y = Input.mousePosition.y;

        //float angleX = mousePosition.x - screenCenter.x;
        //float angleY = mousePosition.y - screenCenter.y;

        //angle = Mathf.Atan(angleY / angleX) * Mathf.Rad2Deg;

        float angleX = Input.mousePosition.x - (Screen.width / 2);

        angle = Mathf.Atan((Input.mousePosition.y - (Screen.height / 2)) / angleX) * Mathf.Rad2Deg;
        //angle += 90.0f;
        //if (angle < 0)
        //    angle += 180.0f;
        //if (angle > 180)
        //    angle += 180.0f;
        if (angleX < 0)
            angle += 180;
        angle += 180;

        transform.eulerAngles = new Vector3(0, -angle, 0);
    }
}
