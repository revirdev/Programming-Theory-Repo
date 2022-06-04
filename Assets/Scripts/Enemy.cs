using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public float health = 100f;
    public Transform Player;

    public void TakeDamage(float amount)
    {


        health -= amount;
        if (health <= 0f)
        {
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        enemy.SetDestination(Player.position);
    }
}
