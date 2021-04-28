using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    ammo ,
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
    public ItemType item;
    public float life;

    public void Start()
    {
        InstantiateAmmo();
    }
    public void InstantiateAmmo()
    {
        int gunTypeNum = Random.Range(0, 2) + 1;
        ammo.GunType = (Gun)gunTypeNum;
        ammo.AmmoCount = Random.Range(20, 151);
        life = 10;
    }
    public void InstantiateBoost()
    {

    }
    public void Tick()
    {
        boost.Duration -= Time.deltaTime;
    }
}
