/*
 * Filename : Player.cs
 * Purpose  : Hold player stats and values
 * Date     : 4/24/21                                                           */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float maxHealth = 50.0f;

    public float speed;
    public float playerStamina;
    public float maxStamina;
    public float staminaRegenPerSecond;
    public float regenDelay;
    public float staminaDrainPerSecond;
    public float speedMultiplier;
    public float sprintMultiplier;

    public int ammoCount;
    public float score;

    public static Player inst;
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        playerStamina = maxStamina;
    }
    public void ResetPlayer()
    {
        health = maxHealth;
        playerStamina = maxStamina;
        ammoCount = 43; // need to get the weapon manager going to get max ammo from gun for ammoCount value.
        score = 0;
    }
    public void NextWave()
    {
        health = maxHealth;
        playerStamina = maxStamina;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }
}
