using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{

    public Slider healthSlider;
    public Slider staminaSlider;
    public Text waveTimerText;
    public Text waveCountText;
    public Text clipAmmoText;                
    public Text totalAmmoText;               
    public float waveClock;
    public bool activeWave;
    public int waveCount;
    // Start is called before the first frame update
    void Start()
    {
        waveCount = 0;
        waveCountText.text = string.Concat("Wave: ", waveCount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = Player.inst.playerHealth;
        staminaSlider.value = Player.inst.playerStamina;
        clipAmmoText.text = string.Concat(GunScript.roundsInClip.ToString(), "/", GunScript.clipSize.ToString());
        totalAmmoText.text = Player.inst.ammoCount.ToString();
        if(activeWave)
        {
            waveClock += Time.deltaTime;
            waveTimerText.text = formatTime(waveClock);
        }
    }

    void startClock()
    {
        activeWave = true;
        waveClock = 0.0f;
    }
    void stopClock()
    {
        activeWave = false;
    }
    void updateWaveCount()
    {
        waveCount += 1;

    }
    string formatTime(float time)
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
