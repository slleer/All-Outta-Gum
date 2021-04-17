using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public static ZombieManager inst;
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //spawnPoint = new Vector3(-13.0f, 2.5f, -40.0f);
        //zombieTransform.
    }

    public float spawnTimer = 3.0f;
    public GameObject regularZombie;
    public Transform zombieTransform;
    //public Vector3 spawnPoint;
    // Update is called once per frame
    void Update()
    {
        //spawn zombies every 3 seconds
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = 3.0f;
            //instantiate zombie
            //GameObject impactInstant = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //GameObject zombieInstant = Instantiate(regularZombie, spawnPoint);
        }
    }
}
