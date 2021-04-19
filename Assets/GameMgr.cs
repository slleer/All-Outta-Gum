using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;
    public bool betweenWave;
    public float coolDown = 5.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        Time.timeScale = 0;
        betweenWave = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.inst.health <= 0)
        {
            Time.timeScale = 0;
            UIMgr.inst.OnGameOver();
        }
        if(ZombieManager.inst.waveFinishedSpawning && ZombieManager.inst.zombies.Count <= 0)
        {
            if (coolDown < 0)
            {
                if(!betweenWave)
                {
                    Debug.Log("Wave cleared. Gonna display this out later. ");
                    Player.inst.score += (Player.inst.score*3)/UIMgr.inst.waveClock;
                    Time.timeScale = 0;
                    UIMgr.inst.OnGameOver();
                    betweenWave = true;
                }
            }
            coolDown -= Time.deltaTime;
        }
    }
    
    public void StartGame()
    {
        //Initiate wave somehow here
        Time.timeScale = 1;
        UIMgr.inst.OnGameStart();

    }
    public void NewGame()
    {
        //Initiate wave somehow here
        Time.timeScale = 1;
        Debug.Log("NewGame");
        UIMgr.inst.NewGame();
        Player.inst.ResetPlayer();
        ZombieManager.inst.ResetScene();
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
                                Application.Quit();
        #endif
    }
}
