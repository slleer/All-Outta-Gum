using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{


    public float impactForce;


    public float fireRate;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    //public AudioSource shootSound;
    //public AudioSource reloadSound;
    AudioSource shootSoundSrc;
    public AudioClip shootSoundClip;
    public AudioSource reloadSound;
    public AudioSource emptyMagSound;
    float timeToPlay = 0.0f;



    //shotgun specific variables
    public float maxDistance;
    public Quaternion l1 = Quaternion.Euler(0, 8.0f, 0);
    public Quaternion r1 = Quaternion.Euler(0, -8.0f, 0);
    public Quaternion l2 = Quaternion.Euler(0, 16.0f, 0);
    public Quaternion r2 = Quaternion.Euler(0, -16.0f, 0);

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
        */
        fireRate = 1 / shotsPerSecond; 
        reload = true;
        gunType = Gun.shotgun;

        shootSoundSrc = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if (Time.time >= timeToFire)
        {
            reload = true;
            UIMgr.inst.reloadPanel.SetActive(!reload);
        }
        if (ammoCount <= 0 && clipCount <= 0)
        {
            UIMgr.inst.lowAmmoPanel.SetActive(false);
            UIMgr.inst.outOfAmmoPanel.SetActive(true);
        }
        else if (ammoCount <= 0)
        {
            UIMgr.inst.lowAmmoPanel.SetActive(true);
        }
        else
        {
            UIMgr.inst.lowAmmoPanel.SetActive(false);
            UIMgr.inst.outOfAmmoPanel.SetActive(false);
        }
    }
    public override void Init()
    {

    }
    public override void PlayReloadSound()
    {
        reloadSound.Play();
    }
    public override void Reload()
    {
        //if the player has ammo in reserve
        if (ammoCount > 0 && (clipCount < clipSize))
        {
            reload = false;
            UIMgr.inst.reloadPanel.SetActive(!reload);
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
        else if (Time.time > timeToPlay)
        {
            emptyMagSound.Play();
            timeToPlay = Time.time + 0.5f;
        }
    }
    public override void Shoot()
    {
        if(WeaponMgr.inst.canFire)
        {
            reload = true;
            UIMgr.inst.reloadPanel.SetActive(!reload);
            if (clipCount > 0)
            {
                //shoot, delay next shot until current time + fireRate
                muzzleFlash.Play();
                //shootSound.Play();
                shootSoundSrc.PlayOneShot(shootSoundClip);
                RaycastHit hit;
                //hit.rigidbody.
                Vector3 location = weaponObject.transform.position + (new Vector3(0, 1f, 0));
                if (Physics.Raycast(location, weaponObject.transform.forward, out hit, maxDistance))
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
                DrawLine(weaponObject.transform.position, hit.point, Color.white, 0.1f);
                GameObject impactInstant = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactInstant, 2f);
                //timeToFire = Time.time + fireRate;
                //timeToFire = Time.time + 0.25f;
                if (Physics.Raycast(location, l1 * weaponObject.transform.forward, out hit, maxDistance))
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
                DrawLine(weaponObject.transform.position, hit.point, Color.white, 0.1f);
                GameObject impactInstantl1 = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactInstantl1, 2f);
                //timeToFire = Time.time + fireRate;
                if (Physics.Raycast(location, r1 * weaponObject.transform.forward, out hit, maxDistance))
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
                DrawLine(weaponObject.transform.position, hit.point, Color.white, 0.1f);
                GameObject impactInstantr1 = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactInstantr1, 2f);
                //timeToFire = Time.time + fireRate;
                if (Physics.Raycast(location, l2 * weaponObject.transform.forward, out hit, maxDistance))
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
                DrawLine(weaponObject.transform.position, hit.point, Color.white, 0.1f);
                GameObject impactInstantl2 = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactInstantl2, 2f);
                //timeToFire = Time.time + fireRate;
                if (Physics.Raycast(location, r2 * weaponObject.transform.forward, out hit, maxDistance))
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
                DrawLine(weaponObject.transform.position, hit.point, Color.white, 0.1f);

                if (!ItemMgr.inst.bbGumActive)
                    clipCount -= 1;

                GameObject impactInstantr2 = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactInstantr2, 2f);
                timeToFire = Time.time + fireRate;
            }
            else
            {
                //maybe find a sound effect for out of ammo or display text on screen.
                Reload();
            }
        }
    }

}
