using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabarianMovement : PlayerMovement
{
    protected int babarianMaxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    private float babarianSpeed = 10f;
    private float babarianJumpHeight = 2.0f;
    private float babarianSprintingSpeed = 1.5f;

    private void Start()
    {
        currentHealth = babarianMaxHealth;
        healthBar.SetMaxHealth(babarianMaxHealth);
    }
    private void Update()
    {
        speed = babarianSpeed;
        jumpHeight = babarianJumpHeight;
        sprintSpeed = babarianSprintingSpeed;
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }
        base.PlayerMove();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
