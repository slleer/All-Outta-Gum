/*
 * FileName: PlayerMovement.cs
 * Purpose: Implement player movement using WASD + Shift
 * Date: 4/14/21                                        */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    void Start()
    {
        
    }

    public float deltaPosition = 10.0f;
    public float sprintMultiplier = 1.0f;
    public GameObject player;
    //public GameObject playerMesh;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintMultiplier = 3.0f;
        }
        else
            sprintMultiplier = 1.0f;

        if (Input.GetKey(KeyCode.W))
            player.transform.Translate(sprintMultiplier * deltaPosition * Vector3.right * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            player.transform.Translate(sprintMultiplier * deltaPosition * Vector3.left * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            player.transform.Translate(sprintMultiplier * deltaPosition * Vector3.forward * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            player.transform.Translate(sprintMultiplier * deltaPosition * Vector3.back * Time.deltaTime);
        //sprintMultiplier = 1.0f;

    }

    /*void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colliding!");
        //if (collision.gameObject.name == "YourWallName")  // or if(gameObject.CompareTag("YourWallTag"))
        if(collision.gameObject.layer == 9)
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //player.rigidbody.velocity = Vector3.zero;
        }
    }*/
}
