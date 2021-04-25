/*
 * Filename : Zombie.cs
 * Purpose  : Zombie class to enable quick creation of new zombie types
 * Date     : 4/24/21                                                           */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    //health and damage handled by Target

    //variables used to calculate movement
    Vector3 desiredPosition;
    float desiredHeading;
    Vector3 eulerRotation = Vector3.zero;

    //set these in Unity Editor
    public float speed;
    public float turningSpeed;
    public float damagePerSecond;

    //update position using move
    private void Update()
    {
        Move(); //function needed for future animations
    }

    //on collision with player, attack player
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Attack(); //function needed for future animations
        }
    }

    public void Move()
    {
        desiredPosition = Player.inst.transform.position;
        desiredHeading = CalculateAngle(desiredPosition, transform.position);
        while (desiredHeading < 0)
        {
            desiredHeading += 360;
        }
        eulerRotation.y = desiredHeading;
        transform.localEulerAngles = eulerRotation;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Attack()
    {
        Player.inst.TakeDamage(damagePerSecond * Time.deltaTime);
    }
    
    //angle calculation helper
    public float CalculateAngle(Vector3 moveTo, Vector3 currentPosition)
    {
        Vector3 diff = moveTo - currentPosition;
        return -(Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg + 270);
    }

}

    
