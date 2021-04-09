
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10.0f;
    public float range = 100.0f;
    public float impactForce = 30.0f;

    public GameObject weapon;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetButtonDown("Fire1"))
        
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("left click");
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        
        //muzzleFlash.Stop();
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
        //muzzleFlash.Stop();
    }
}
