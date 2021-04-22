/*
 * FileName: GunScript.cs
 * Purpose: Implement basic gun simulation
 * Date: 4/14/21                                        */

using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 20.0f;
    public float range = 100.0f;
    public float impactForce = 30.0f;
    public float fireRate = 0.5f;
    public float reloadRate = 3f;
    public float delay = 0;

    public static int clipSize;           //Have these declared as static so I can call them from UIMgr
    public static int roundsInClip;       //Keep as static for now
    private int maxAmmo;

    public GameObject weapon;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource audioSource;
    public AudioSource reloadSound;

    private float nextTimeToFire;

    bool reload = false;

    private void Start()
    {
        nextTimeToFire = Time.time + 0.1f;
        clipSize = 8;
        roundsInClip = clipSize;
        maxAmmo = 48;
        Player.inst.ammoCount = maxAmmo;
        // need to think about a way to represent infinit ammo for base gun, either here or in Player script
        //put some code here to initialize clipSize and maxAmmo based on the weapon. Should also do this for damage, range, etc.
        //Probably make a gun class that will represent the different guns, include a gun class object in this script, initialized through the editor
        //and add a function here that allows to 'switch' weapons.
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
            Reload();
        //check for left mouse, nextTimeToFire, and not reloading
        if ((Input.GetMouseButton(0)) && (Time.time >= nextTimeToFire) && (reload == false))
        {
            //if(Player.inst.ammoCount > 0)
            if(roundsInClip > 0)
            {
                Shoot();
                delay += fireRate;
                nextTimeToFire = Time.time + delay;
                delay = 0;
            }
            else
            {
                //maybe find a sound effect for out of ammo or display text on screen.
                Reload();
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
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }
            if (hit.rigidbody != null) //section used for adding force to rigidbodies on hit ex. bullet impact physics
            {
                //Debug.Log("rigidbody not null");
                //hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }

        roundsInClip -= 1;

        GameObject impactInstant = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactInstant, 2f);
    }

    void Reload()
    {
        reload = true;
        //if the player has ammo in reserve
        if (Player.inst.ammoCount > 0)
        {
            UIMgr.inst.outOfAmmoPanel.SetActive(false);
            nextTimeToFire += reloadRate;
            reloadSound.Play();
            //reload is successful

            if(roundsInClip > 0){
                //two scenarios, one is there is enough ammo to fill clip
                if (Player.inst.ammoCount >= clipSize)
                {
                    Player.inst.ammoCount -= (clipSize - roundsInClip);
                    roundsInClip = clipSize;
                }
                //else not enough ammo to fill clip
                else
                {
                    Player.inst.ammoCount = (clipSize - roundsInClip);
                    roundsInClip = (Player.inst.ammoCount + roundsInClip < clipSize ? Player.inst.ammoCount + roundsInClip : clipSize);
                }

            }
            else {
                //two scenarios, one is there is enough ammo to fill clip
                if (Player.inst.ammoCount >= clipSize)
                {
                    roundsInClip = clipSize;
                    Player.inst.ammoCount -= clipSize;
                }
                //else not enough ammo to fill clip
                else
                {
                    roundsInClip = Player.inst.ammoCount;
                    Player.inst.ammoCount -= roundsInClip;
                }

            }

            //reload
            reload = false;
        }
        else
        {
            //Display to HUD "OUT OF AMMMO"
            UIMgr.inst.outOfAmmoPanel.SetActive(true);
            reload = false;
        }
    }
}
