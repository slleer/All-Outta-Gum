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
    public float heathBoostMult;
    public float staminaBoostMult;

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
        //health = maxHealth;
        playerStamina = maxStamina;
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }
    private void OnTriggerEnter(Collider other)
    {
        Item item = other.gameObject.GetComponent<Item>();
        if(!item.boostActive)
        {
            //other.GetComponent<AudioSource>().Play();
            //item.pickUpSound.Play();
            ItemMgr.inst.pickUpSound.Play();
            if (item.item == ItemType.ammo)
            {
                foreach (Weapon weap in WeaponMgr.inst.weapons)
                {
                    if (weap.gunType == item.ammo.GunType)
                    {
                        weap.ammoCount += item.ammo.AmmoCount;
                    }
                    //Debug.Log("Shotgun");
                }
                item.life = 0;
                item.Tick();
            }
            else if (item.item.Equals(ItemType.boost))
            {
                //Debug.Log("Item triggered " + item.boost.BoostType + " duration " + item.boost.Duration);
                other.gameObject.GetComponent<Renderer>().enabled = false;
                item.boostActive = true;
                //Debug.Log("Duration on trigger: " + item.boost.Duration);
                UIMgr.inst.ActivateBoostBar((int)item.boost.BoostType, item.boost.Duration);
                item.boostTimer = item.boost.Duration;
                item.life = item.boost.Duration + 1;
            }
        }
    }
}
