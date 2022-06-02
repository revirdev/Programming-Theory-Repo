using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour 
{

    public BabarianWeapon BabWeap;
    public GameObject HitParticle;
    public GameObject enemy;

    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && BabWeap.isAttacking == true)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
            other.GetComponent<Animator>().SetTrigger("Hit");
            Instantiate(HitParticle, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z),
                other.transform.rotation);   
        }
    }

}
