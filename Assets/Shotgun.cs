using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{


    public float impactForce;


    public float fireRate;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource shootSound;
    public AudioSource reloadSound;

    //shotgun specific variables
    public float maxDistance;
    public Quaternion l1 = Quaternion.Euler(0, 4.0f, 0);
    public Quaternion r1 = Quaternion.Euler(0, -4.0f, 0);
    public Quaternion l2 = Quaternion.Euler(0, 8.0f, 0);
    public Quaternion r2 = Quaternion.Euler(0, -8.0f, 0);

    public void Start()
    {
        /*
        clipSize = 4;
        clipCount = clipSize;
        ammoCapacity = 48;
        ammoCount = ammoCapacity - clipSize;
        baseDmg = 5.0f;
        bonusDmg = 1;
        impactForce = 1500;
        shotsPerSecond = 1f;
        reloadRate = 1.5f;
        fireRate = 1 / shotsPerSecond; 
        */
        reload = true;
        gunType = Gun.shotgun;
    }
    public void Update()
    {
        if (Time.time >= timeToFire)
            reload = true;
    }
    public override void Init()
    {

    }
    public override void Reload()
    {
        //if the player has ammo in reserve
        if (ammoCount > 0 && (clipCount < clipSize))
        {
            reload = false;
            UIMgr.inst.outOfAmmoPanel.SetActive(false);
            timeToFire = Time.time + reloadRate;
            reloadSound.Play();

            if (clipCount > 0)
            {
                //two scenarios, one is there is enough ammo to fill clip
                if (ammoCount >= clipSize)
                {
                    ammoCount -= (clipSize - clipCount);
                    clipCount = clipSize;
                }
                //else not enough ammo to fill clip
                else
                {
                    ammoCount = (clipSize - clipCount);
                    clipCount = (ammoCount + clipCount < clipSize ? ammoCount + clipCount : clipSize);
                }
            }
            else
            {
                //two scenarios, one is there is enough ammo to fill clip
                if (ammoCount >= clipSize)
                {
                    clipCount = clipSize;
                    ammoCount -= clipSize;
                }
                //else not enough ammo to fill clip
                else
                {
                    clipCount = ammoCount;
                    ammoCount -= clipCount;
                }
            }
        }
        if (ammoCount <= 0)
        {
            //Display to HUD "OUT OF AMMMO"
            UIMgr.inst.outOfAmmoPanel.SetActive(true);
        }
    }
    public override void Shoot()
    {

        if (clipCount > 0)
        {
            //shoot, delay next shot until current time + fireRate
            muzzleFlash.Play();
            shootSound.Play();
            RaycastHit hit;
            //hit.rigidbody.
            if (Physics.Raycast(weaponObject.transform.position, weaponObject.transform.forward, out hit, maxDistance))
            {
                Debug.DrawLine(weaponObject.transform.position, hit.point, Color.yellow, 2);
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    if (hit.rigidbody.gameObject.layer == 12)
                        target.TakeDamage(baseDmg / 10); //physics objects get reduced damage
                    else
                        target.TakeDamage(baseDmg); //zombies get full damage
                }
                if (hit.rigidbody != null) //section used for adding force to rigidbodies on hit ex. bullet impact physics
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
            }
            if (Physics.Raycast(weaponObject.transform.position, l1*weaponObject.transform.forward, out hit, maxDistance))
            {
                Debug.DrawLine(weaponObject.transform.position, hit.point, Color.yellow, 2);
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    if (hit.rigidbody.gameObject.layer == 12)
                        target.TakeDamage(baseDmg / 10); //physics objects get reduced damage
                    else
                        target.TakeDamage(baseDmg); //zombies get full damage
                }
                if (hit.rigidbody != null) //section used for adding force to rigidbodies on hit ex. bullet impact physics
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
            }
            if (Physics.Raycast(weaponObject.transform.position, r1*weaponObject.transform.forward, out hit, maxDistance))
            {
                Debug.DrawLine(weaponObject.transform.position, hit.point, Color.yellow, 2);
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    if (hit.rigidbody.gameObject.layer == 12)
                        target.TakeDamage(baseDmg / 10); //physics objects get reduced damage
                    else
                        target.TakeDamage(baseDmg); //zombies get full damage
                }
                if (hit.rigidbody != null) //section used for adding force to rigidbodies on hit ex. bullet impact physics
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
            }
            if (Physics.Raycast(weaponObject.transform.position, l2*weaponObject.transform.forward, out hit, maxDistance))
            {
                Debug.DrawLine(weaponObject.transform.position, hit.point, Color.yellow, 2);
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    if (hit.rigidbody.gameObject.layer == 12)
                        target.TakeDamage(baseDmg / 10); //physics objects get reduced damage
                    else
                        target.TakeDamage(baseDmg); //zombies get full damage
                }
                if (hit.rigidbody != null) //section used for adding force to rigidbodies on hit ex. bullet impact physics
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
            }
            if (Physics.Raycast(weaponObject.transform.position, r2*weaponObject.transform.forward, out hit, maxDistance))
            {
                Debug.DrawLine(weaponObject.transform.position, hit.point, Color.yellow, 2);
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    if (hit.rigidbody.gameObject.layer == 12)
                        target.TakeDamage(baseDmg / 10); //physics objects get reduced damage
                    else
                        target.TakeDamage(baseDmg); //zombies get full damage
                }
                if (hit.rigidbody != null) //section used for adding force to rigidbodies on hit ex. bullet impact physics
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
            }
            clipCount -= 1;

            GameObject impactInstant = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactInstant, 2f);
            timeToFire = Time.time + fireRate;
        }
        else
        {
            //maybe find a sound effect for out of ammo or display text on screen.
            Reload();
        }
    }

}
