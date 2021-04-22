using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public static ZombieManager inst;
    public List<GameObject> zombies = new List<GameObject>();
    public float spawnTimer = 1.5f;
    public GameObject regularZombie;

    public bool waveDefeated;
    public bool waveFinishedSpawning;
    public int numOfZombiesInWave;
    public int zombiesSpawnedSoFar;

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

                zombies.Add(Instantiate(regularZombie, spawnPoints[Random.Range(0, spawnPoints.Count)]));
                zombiesSpawnedSoFar++;
            }
        }
        if (numOfZombiesInWave == zombiesSpawnedSoFar)
        {
            waveFinishedSpawning = true;
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
}
