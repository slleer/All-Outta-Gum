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

    }

    public float spawnTimer = 3.0f;
    public GameObject regularZombie;
    public Vector3 spawnPoint;
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
            GameObject zombieInstant = Instantiate(regularZombie, spawnPoint, Quaternion.identity);
        }
    }
}
