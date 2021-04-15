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
    public float fireRate = 1.0f;

    public GameObject weapon;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource audioSource;

    private float nextTimeToFire = 0.0f;

    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 0.5f;
            Shoot();
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
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }

        GameObject impactInstant = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Object.Destroy(impactInstant, 2f);
    }
}
