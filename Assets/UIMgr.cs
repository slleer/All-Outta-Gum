/*
 * Filename : UIMgr.cs
 * Purpose  : UI connection to game
 * Date     : 4/24/21                                                           */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{

    public Slider healthSlider;
    public Slider staminaSlider;
    public GameObject hudPanel;
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject outOfAmmoPanel;
    public Text waveTimerText;
    public Text waveCountText;
    public Text clipAmmoText;                
    public Text totalAmmoText;
    public Text scoreText;
    public float waveClock;
    public bool activeWave;
    public int waveCount;

    public static UIMgr inst;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        waveCount = 0;
        waveCountText.text = string.Concat("Wave: ", waveCount.ToString());
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = Player.inst.health;
        staminaSlider.value = Player.inst.playerStamina;
        clipAmmoText.text = string.Concat(GunScript.roundsInClip.ToString(), "/", GunScript.clipSize.ToString());
        totalAmmoText.text = Player.inst.ammoCount.ToString();
        if(activeWave)
        {
            waveClock += Time.deltaTime;
            waveTimerText.text = FormatTime(waveClock);
        }
    }
    public void OnGameStart()
    {
        startPanel.SetActive(false);
        UpdateWaveCount();
        StartClock();
    }
    void StartClock()
    {
        activeWave = true;
        waveClock = 0.0f;
    }
    void StopClock()
    {
        activeWave = false;
    }
    void UpdateWaveCount()
    {
        waveCount += 1;
        waveCountText.text = string.Concat("Wave: ", waveCount.ToString());

    }
    public void OnGameOver()
    {
        gameOverPanel.SetActive(true);
        scoreText.text = string.Concat("Score: ", ((int)Player.inst.score).ToString());
    }
    //called to reset game view
    public void NewGame()
    {
        gameOverPanel.SetActive(false);
        waveCount = 0;
        UpdateWaveCount();
        StartClock();
    }
    // Format time for wave timer count
    string FormatTime(float time)
    {
        string time_as_str = "";
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        if(seconds < 10)
        {
            time_as_str = string.Concat(minutes, ":0", seconds);
        }
        else
        {
            time_as_str = string.Concat(minutes, ":", seconds);
        }
        return time_as_str;
    }
}
