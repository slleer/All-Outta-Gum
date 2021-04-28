/*
 * Filename : ZombieMgr.cs
 * Purpose  : Spawn zombies and handle zombie logic
 * Date     : 4/24/21                                                           */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMgr : MonoBehaviour
{
    public static ZombieMgr inst;
    public List<GameObject> zombies = new List<GameObject>();
    public float spawnTimer = 1.5f;
    public GameObject regularZombie;
    public GameObject quickZombie;
    public GameObject strongZombie;

    public bool waveDefeated;
    public bool waveFinishedSpawning;
    public int numOfZombiesInWave;
    public int zombiesSpawnedSoFar;
    public float zombieIncreasePercent;
    public int fastZombieNumber;
    public int strongZombieNumber;
    public float delay = 3;


    public bool doOnce = false;

    public List<Transform> spawnPoints;

    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        waveFinishedSpawning = false;
        numOfZombiesInWave = 8;
        zombiesSpawnedSoFar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waveFinishedSpawning)
        {
            waveDefeated = false;
            //spawn zombies every 1.5 seconds
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else
            {
                spawnTimer = 1.5f;
                //instantiate zombie type at spawnPoint[random] with rotation identity
                //add instance of zombie to List of GameObjects
                if (zombiesSpawnedSoFar % fastZombieNumber == 0)
                {
                    zombies.Add(Instantiate(quickZombie, spawnPoints[Random.Range(0, spawnPoints.Count)]));
                }
                else if (zombiesSpawnedSoFar % strongZombieNumber == 0)
                {
                    zombies.Add(Instantiate(strongZombie, spawnPoints[Random.Range(0, spawnPoints.Count)]));
                }
                else
                {
                    zombies.Add(Instantiate(regularZombie, spawnPoints[Random.Range(0, spawnPoints.Count)]));
                }
                zombiesSpawnedSoFar++;
            }
        }
        if (numOfZombiesInWave == zombiesSpawnedSoFar)
        {
            waveFinishedSpawning = true;
        }
        if(waveFinishedSpawning)
        {
            if (zombies.Count == 0)
            {
                UIMgr.inst.StopClock();
                if(delay <= 0)
                    waveDefeated = true;
                delay -= Time.deltaTime; 
            }
        }
    }

    public void ResetScene()
    {
        foreach(GameObject zombie in zombies)
        {
            Destroy(zombie);
        }
        zombies.Clear();
        waveFinishedSpawning = false;
        numOfZombiesInWave = 8;
        zombiesSpawnedSoFar = 0;
        
    }
    public void NextWave()
    {
        zombies.Clear();
        waveFinishedSpawning = false;
        numOfZombiesInWave += (int)(numOfZombiesInWave * zombieIncreasePercent);
        zombiesSpawnedSoFar = 0;
        waveDefeated = false;
        delay = 3;
    }
}
