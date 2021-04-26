using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gun
{
    pistol,
    assaultRifle,
    shotgun
}

public class Weapon : MonoBehaviour
{
    public float baseDmg;
    public float bonusDmg;
    public float shotsPerSecond;
    public int clipSize;
    public int clipCount;
    public int ammoCapacity;
    public int ammoCount;
    public float reloadRate;
    public float timeToFire;
    public bool reload;
    public Weapon weaponObject;
    public Gun gunType;



    public virtual void Init()
    {

    }
    public virtual void Reload()
    {

    }
    public virtual void Shoot()
    {

    }


}
