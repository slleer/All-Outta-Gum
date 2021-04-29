using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{

    public float impactForce;
    public float fireRate;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    //public AudioSource shootSound;
    AudioSource shootSoundSrc;
    public AudioSource reloadSound;
    public AudioClip shootSoundClip;
    //public AudioClip emptyMagSoundClip;
    public AudioSource emptyMagSound;
    float timeToPlay = 0.0f;

    public void Start() 
    {
        /*
        clipSize = 8;
        clipCount = clipSize;
        ammoCapacity = 480;
        ammoCount = ammoCapacity - clipSize;
        baseDmg = 10.0f;
        bonusDmg = 1;
        impactForce = 1000;
        shotsPerSecond = 3;
        reloadRate = 1.5f;
        fireRate = 1 / shotsPerSecond;
        */
        fireRate = 1 / shotsPerSecond;
        reload = true;
        gunType = Gun.pistol;
        timeToFire = Time.time + .01f;

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
        //no ammo left
        else if(Time.time > timeToPlay)
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
                shootSoundSrc.PlayOneShot(shootSoundClip);
                RaycastHit hit;
                //hit.rigidbody.
                Vector3 location = weaponObject.transform.position + (new Vector3(0, 1f, 0));
                //Debug.Log(location);
                if (Physics.Raycast(location, weaponObject.transform.forward, out hit))
                {
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
                //Debug.Log(location + " " + weaponObject.transform.forward + " " + hit.point + "before drawline");
                DrawLine(weaponObject.transform.position, hit.point, Color.white, 0.1f);
                clipCount -= 1;

                GameObject impactInstant = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactInstant, 2f);
                timeToFire = Time.time + fireRate;
                //timeToFire = Time.time;
            }
            else
            {
                //maybe find a sound effect for out of ammo or display text on screen.
                Reload();
            }
        }
    }
}
