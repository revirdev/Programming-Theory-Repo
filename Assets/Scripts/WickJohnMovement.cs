using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WickJohnMovement : PlayerMovement
{
    protected int WJMaxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    private float WJSpeed = 12f;
    private float WJJumpHeight = 2.3f;
    private float WJSprintingSpeed = 1.8f;


    private void Start()
    {
        currentHealth = WJMaxHealth;
        healthBar.SetMaxHealth(WJMaxHealth);
    }
    private void Update()
    {
        speed = WJSpeed;
        jumpHeight = WJJumpHeight;
        sprintSpeed = WJSprintingSpeed;
        base.PlayerMove();
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
