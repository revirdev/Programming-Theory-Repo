using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabarianWeapon : MonoBehaviour
{
    public GameObject Axe;
    private bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public bool isAttacking = false;
    public float damage = 20f;
    public AudioClip AxeAttackSound;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                AxeAttack();
            }
        }
    }

    public void AxeAttack()
    {
        CanAttack = false;
        isAttacking = true;
        Animator anim = Axe.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(AxeAttackSound, 0.5f);
        StartCoroutine(ResetAttackCoolDown());
        
    }

    IEnumerator ResetAttackCoolDown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }
}
