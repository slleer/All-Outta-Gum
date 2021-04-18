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

    public float spawnTimer = 1.5f;
    public GameObject regularZombie;

    public bool waveFinishedSpawning = false;
    public int numOfZombiesInWave = 8;
    public int zombiesSpawnedSoFar = 0;
    //final spawnPoint variable
    Vector3 spawnPoint;
    // Update is called once per frame
    void Update()
    {
        if (waveFinishedSpawning == false)
        {
                //spawn zombies every 1.5 seconds
                if (spawnTimer > 0)
                {
                    spawnTimer -= Time.deltaTime;
                }
                else
                {
                    spawnTimer = 1.5f;
                    //instantiate zombie type at spawnPoint[random] with rotation identity
                    GameObject zombieInstant = Instantiate(regularZombie, spawnPoints[ChooseRandomSpawnIndex()], Quaternion.identity);
                    zombiesSpawnedSoFar++;
                }
        }
        if(numOfZombiesInWave == zombiesSpawnedSoFar)
        {
            waveFinishedSpawning = true;
        }
        
    }

    //spawnPoint array
    public Vector3[] spawnPoints = new[] {
        new Vector3(61.6f, 2.6f, 0.38f),    //spawnPointNorth
        new Vector3(0f, 2.6f, -56.4f),    //spawnPointEast
        new Vector3(-56.4f, 2.6f, 1.13f),    //spawnPointSouth
        new Vector3(0f, 2.6f, 58.6f) };  //spawnPointWest

    //choose random index of array spawnPoints
    int ChooseRandomSpawnIndex()
    {
        int index = Random.Range(0, spawnPoints.Length);
        return index;
    }
}
