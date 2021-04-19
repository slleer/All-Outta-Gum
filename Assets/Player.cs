using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    public static Player inst;

    public float playerStamina;
    public float maxStamina;
    public int ammoCount;
    public float score;

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
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }
}
