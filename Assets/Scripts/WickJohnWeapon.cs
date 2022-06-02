using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WickJohnWeapon : MonoBehaviour
{
    public float damage = 10f;
    public float range = 300f;
    public float fireRate = 12f;

    public GameObject hitParticle;
    public AudioClip shootingSound;

    public float impactForce = 60f;
    private float nextTimeToFire = 0f;

    public Camera fpsCam;
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(shootingSound, 0.5f);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject hitGO = Instantiate(hitParticle, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(hitGO, 1.5f);
        }
        
    }
}
