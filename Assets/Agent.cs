using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float health = 50.0f;
    public float maxHealth = 50.0f;
    public Vector3 position = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public float desiredSpeed;
    public float maxSpeed;
    public float minSpeed;

    public float heading; // degrees
    public float desiredHeading; // degrees

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
