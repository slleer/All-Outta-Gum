using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct Ammo
{
    public Gun GunType { get; set; }
    public int AmmoCount { get; set; }
}
public struct Boost
{
    public PowerUp BoostType { get; set; }
    public float Duration { get; set; }
}
public enum ItemType
{
    ammo,
    gun,
    boost
}
public enum PowerUp
{
    bubbleGum,
    speedBoost,
    healthBoost
}
public class Item : MonoBehaviour
{
    public Ammo ammo;
    public Boost boost;
    public bool boostActive;
    public ItemType item;
    public float life;
    public float boostTimer;
    public GameObject shotgunImg;
    public GameObject arImg;
    public string itemLabel;
    public Text itemText;
    public AudioSource pickUpSound;
    public Material ammoMaterial;
    public Material bbGumMaterial;
    public Material healthMaterial;
    public Material staminaMaterial;

    public void Start()
    {
        //InstantiateAmmo();
        boostActive = false;
        boostTimer = 0;

    }
    public void FixedUpdate()
    {
        if(boostActive && !GameMgr.inst.betweenWave)
        {
            
            if(boost.BoostType.Equals(PowerUp.bubbleGum))
            {
                //Debug.Log("in bubbleGum pre tick");
                Player.inst.health = Player.inst.maxHealth + .1f;
                Player.inst.playerStamina = Player.inst.maxStamina + 1;
                Tick();
            }
            else if(boost.BoostType.Equals(PowerUp.healthBoost))
            {
                //Debug.Log("in healthboost pre tick");
                Player.inst.health = Player.inst.maxHealth;
                Tick();
            }
            else
            {
                //Debug.Log("in staminaboost pre tick");
                Player.inst.playerStamina = Player.inst.maxStamina + 1;
                Tick();
            }
        }
    }
    public void InstantiateAmmo()
    {
        item = ItemType.ammo;
        int gunTypeNum = Random.Range(0, 2) + 1;
        ammo.GunType = (Gun)gunTypeNum;
        if(ammo.GunType.Equals(Gun.assaultRifle))
        {
            ammo.AmmoCount = Random.Range(30, 151);
            arImg.SetActive(true);
        }
        else
        {
            ammo.AmmoCount = Random.Range(10, 51);
            shotgunImg.SetActive(true);
        }
        itemLabel = GetAmmoText();
        life = 10;
    }
    public void InstantiateBoost()
    {
        item = ItemType.boost;
        //int chance = Random.Range(1, 101);
        //if(chance <= 4)

        int boostTypeNum = Random.Range(0, 3);
        boost.BoostType = (PowerUp)boostTypeNum;
        boost.Duration = Random.Range(5, 31);
        life = boost.Duration;
        boostTimer = boost.Duration;
        Debug.Log("Boost Instantiated " + boost.BoostType);
        itemLabel = GetBoostText();
    }
    public void Tick()
    {
        if (boostTimer > 0 && boostActive)
        {
            UIMgr.inst.boostSlider.value = boostTimer;
            boostTimer -= Time.deltaTime;
        }
        else if (boostActive)
        {
            UIMgr.inst.boostPanel.SetActive(false);
        }

        life -= Time.deltaTime;

        if (life <= 0)
        {
            
            Die();
        }
    }
    public string GetAmmoText()
    {
        string str = "";
        if (ammo.GunType.Equals(Gun.assaultRifle))
        {
            str = "Assault Rifle Ammo!";
            
        }
        else
        {
            str = "Shotgun Ammo!";

        }
        itemText.color = new Color32(191, 191, 191, 255);
        gameObject.GetComponent<Renderer>().material = ammoMaterial;
        return str;
    }
    public string GetBoostText()
    {
        string str = "";
        if (boost.BoostType.Equals(PowerUp.bubbleGum))
        {
            str = "Bubble Gum PowerUp!";
            itemText.color = new Color32(229, 25, 207, 255);
            gameObject.GetComponent<Renderer>().material = bbGumMaterial;
        }
        else if (boost.BoostType.Equals(PowerUp.healthBoost))
        {
            str = "Health PowerUp!";
            itemText.color = new Color32(238, 25, 25, 255);
            gameObject.GetComponent<Renderer>().material = healthMaterial;
        }
        else
        {
            str = "Stamina PowerUp!";
            itemText.color = new Color32(34, 155, 218, 255);
            gameObject.GetComponent<Renderer>().material = staminaMaterial;
        }
        return str;
    }
    public void Die()
    {
        ItemMgr.inst.items.Remove(gameObject);
        if (ammo.GunType.Equals(Gun.assaultRifle))
        {
            arImg.SetActive(false);
        }
        else
        {
            shotgunImg.SetActive(false);
        }
        Debug.Log("we get to die");
        Destroy(gameObject);
    }
}
