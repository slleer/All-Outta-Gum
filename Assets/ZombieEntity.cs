﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEntity : MonoBehaviour
{
    public Vector3 desiredPosition;
    public float desiredHeading;
    public float speed;
    public float turningSpeed;
    private float damagePerSec = 1;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        speed = 8.0f;
    }

    void OnCollisionStay(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "PlayerMesh")
        {
            Player.inst.TakeDamage(damagePerSec * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        desiredPosition = player.transform.position;
        desiredHeading = CalculateAngle(desiredPosition, transform.position);
        while (desiredHeading < 0)
        {
            desiredHeading += 360;
        }
        eulerRotation.y = desiredHeading;
        transform.localEulerAngles = eulerRotation;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public Vector3 eulerRotation = Vector3.zero;

    float CalculateAngle(Vector3 moveTo, Vector3 currentPosition)
    {
        Vector3 diff = moveTo - currentPosition;
        return -(Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg + 270);
    }

}
