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
    public float coolDown = 10.0f;

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
        if(ZombieMgr.inst.waveDefeated)
        {
            if(!betweenWave)
            {
                Player.inst.score += (Player.inst.score * 3) / UIMgr.inst.waveClock;
                UIMgr.inst.BetweenWaves();
                coolDown = UIMgr.inst.waveCountDownClock;
                betweenWave = true;
            }
            if (coolDown < 0)
            {

                UIMgr.inst.betweenWavesPanel.SetActive(false);
                Debug.Log("Wave cleared. Gonna display this out later. ");
                UIMgr.inst.UpdateWaveCount();
                UIMgr.inst.StartClock();
                ZombieMgr.inst.NextWave();
                Player.inst.NextWave();
                WeaponMgr.inst.NextWave();
                WeaponMgr.inst.selectedWeapon.timeToFire = Time.time + 0.01f;
                betweenWave = false;
                //ZombieMgr.inst.waveDefeated = false;
                Debug.Log(ZombieMgr.inst.waveDefeated);
                coolDown = 10;
                
                
            }
            coolDown = UIMgr.inst.waveCountDownClock;
        }
    }
    
    public void StartGame()
    {
        //Initiate wave somehow here
        Time.timeScale = 1;
        UIMgr.inst.OnGameStart();
        foreach(Weapon weap in WeaponMgr.inst.weapons)
        {
            if (weap != WeaponMgr.inst.selectedWeapon)
                weap.gameObject.SetActive(false);
        }

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
