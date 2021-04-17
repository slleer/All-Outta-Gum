/*
 * FileName: GunScript.cs
 * Purpose: Implement basic gun simulation
 * Date: 4/14/21                                        */

using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10.0f;
    public float range = 100.0f;
    public float impactForce = 30.0f;
    public float fireRate = 0.5f;
    public float reloadRate = 1f;
    public float delay = 0;

    public static int clipSize;           //Have these declared as static so I can call them from UIMgr
    public static int roundsInClip;       //Keep as static for now
    public int maxAmmo;            

    public GameObject weapon;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource audioSource;

    private float nextTimeToFire;

    private void Start()
    {
        clipSize = 8;
        roundsInClip = clipSize;
        maxAmmo = 48; // need to think about a way to represent infinit ammo for base gun, either here or in Player script 
        //put some code here to initialize clipSize and maxAmmo based on the weapon. Should also do this for damage, range, etc.
        //Probably make a gun class that will represent the different guns, include a gun class object in this script, initialized through the editor
        //and add a function here that allows to 'switch' weapons. 
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            if(Player.inst.ammoCount > 0)
            {
                Shoot();
                delay += fireRate;
                nextTimeToFire = Time.time + delay;
                delay = 0;
            }
            else
            {
                //maybe find a sound effect for out of ammo or display text on screen.
            }
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        audioSource.Play();
        RaycastHit hit;
        if(Physics.Raycast(weapon.transform.position, weapon.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                Debug.Log("rigidbody not null");
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
        Player.inst.ammoCount -= 1;
        roundsInClip -= 1;
        if(roundsInClip < 1 && Player.inst.ammoCount > 0)
        {
            if (clipSize <= Player.inst.ammoCount)
            {
                roundsInClip = clipSize;
                delay += reloadRate;
            }
            else
            {
                roundsInClip = Player.inst.ammoCount % clipSize;
            }
        }

        GameObject impactInstant = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactInstant, 2f);
    }
}
