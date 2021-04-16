using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCollideWithWalls : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("colliding with walls!");
            //player.rigidbody.velocity = Vector3.zero;
        }
    }
}
