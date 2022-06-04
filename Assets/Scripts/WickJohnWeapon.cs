using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WickJohnWeapon : MonoBehaviour
{
    protected float damage = 10f;
    protected float range = 300f;
    protected float fireRate = 12f;

    public GameObject hitParticle;
    public AudioClip shootingSound;

    public float impactForce = 60f;
    private float nextTimeToFire = 0f;

    public Camera fpsCam;
    private void Update()
    {
        if (PauseMenu.GameIsPause == false)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        AudioSource ac = GetComponent<AudioSource>();
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("shoot");
        ac.PlayOneShot(shootingSound, 0.3f);
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
