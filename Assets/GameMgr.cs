/*
 * Filename : GameMgr.cs
 * Purpose  : Manage waves, time, and game start/stop
 * Date     : 4/24/21                                                           */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;
    public bool betweenWave;
    public float coolDown = 5.0f;

    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        Time.timeScale = 0;
        betweenWave = false;
    }

    void Update()
    {
        if(Player.inst.health <= 0)
        {
            Time.timeScale = 0;
            UIMgr.inst.OnGameOver();
        }
        if(ZombieMgr.inst.waveFinishedSpawning && ZombieMgr.inst.zombies.Count <= 0)
        {
            if (coolDown < 0)
            {
                if(!betweenWave)
                {
                    Debug.Log("Wave cleared. Gonna display this out later. ");
                    Player.inst.score += (Player.inst.score*3)/UIMgr.inst.waveClock;
                    Time.timeScale = 0;
                    WeaponMgr.inst.selectedWeapon.timeToFire = Time.time + 0.01f;
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
        //reset scene completely
        SceneManager.LoadScene("main");
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
