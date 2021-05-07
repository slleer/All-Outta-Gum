/*
 * Filename : UIMgr.cs
 * Purpose  : UI connection to game
 * Date     : 4/24/21                                                           */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMgr : MonoBehaviour
{

    public Slider healthSlider;
    public Slider staminaSlider;
    public GameObject hudPanel;
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject outOfAmmoPanel;
    public GameObject pausePanel;
    public GameObject reloadPanel;
    public GameObject lowAmmoPanel;
    public GameObject betweenWavesPanel;
    public GameObject boostPanel;
    public GameObject controlsPanel;
    public GameObject creditsPanel;
    public Text boostPanelText;
    public Slider boostSlider;
    public Image boostFillImg;
    public Text waveTimerText;
    public Text waveCountText;
    public Text clipAmmoText;                
    public Text totalAmmoText;
    public Text scoreText;
    public Text betweenWaveCountDownText;
    public Text betweenWaveScoreText;
    public Text betweenWaveZombieCountText;
    public float waveClock;
    public float waveCountDownClock;
    public bool activeWave;
    public int waveCount;
    public int someVal = 0; //used for debugging;

    public static UIMgr inst;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        waveCount = 1;
        waveCountDownClock = 10;
        waveCountText.text = string.Concat("Wave: ", waveCount.ToString());
        gameOverPanel.SetActive(false);
        healthSlider.maxValue = Player.inst.maxHealth;
        staminaSlider.maxValue = Player.inst.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = Player.inst.health;
        staminaSlider.value = Player.inst.playerStamina;
        
        clipAmmoText.text = string.Concat(WeaponMgr.inst.selectedWeapon.clipCount.ToString(), "/", WeaponMgr.inst.selectedWeapon.clipSize.ToString());
        totalAmmoText.text = WeaponMgr.inst.selectedWeapon.ammoCount.ToString();

        if(activeWave)
        {
            waveClock += Time.deltaTime;
            waveTimerText.text = FormatTime(waveClock);
        }
        else
        {
            waveCountDownClock -= Time.deltaTime;
            betweenWaveCountDownText.text = string.Concat("Next Wave: ", FormatTime(waveCountDownClock));
        }
    }
    public void ActivateBoostBar(int boostType, float duration)
    {
        boostPanel.SetActive(true);
        Debug.Log("Duration at activate: " + duration);
        boostSlider.maxValue = duration;
        if(boostType == 0)
        {
            boostPanelText.text = "Bubble Gum!";
            boostFillImg.color = new Color32(229, 25, 207, 255);
        }
        else if(boostType == 2)
        {
            boostPanelText.text = "Health Boost!";
            boostFillImg.color = new Color32(238, 25, 25, 255);
        }
        else
        {
            boostPanelText.text = "Stamina Boost!";
            boostFillImg.color = new Color32(34, 155, 218, 255);
        }
    }
    public void BetweenWaves()
    {
        betweenWavesPanel.SetActive(true);
        betweenWaveScoreText.text = string.Concat("Score: ", ((int)Player.inst.score).ToString());
        betweenWaveZombieCountText.text = string.Concat("Most Zombies at Once: ", ZombieMgr.inst.mostZsAtOnce.ToString(), "\nTotal Zombies in Wave: ", ZombieMgr.inst.numOfZombiesInWave);
        waveCountDownClock = 10.0f;
        betweenWaveCountDownText.text = string.Concat("Next Wave: ", FormatTime(waveCountDownClock));

    }
    public void OnGameStart()
    {
        //startPanel.SetActive(false);
        UpdateWaveCount();
        StartClock();
    }
    public void StartClock()
    {
        activeWave = true;
        waveClock = 0.0f;
    }
    public void StopClock()
    {
        activeWave = false;
    }
    public void UpdateWaveCount()
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
    public void DisplayControlsPanel()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        controlsPanel.SetActive(!controlsPanel.activeSelf);
    }
    public void DisplayCreditsPanel()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        creditsPanel.SetActive(!creditsPanel.activeSelf);
    }
    public void MainMenu()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
        #else
                        Application.Quit();
        #endif
        
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
