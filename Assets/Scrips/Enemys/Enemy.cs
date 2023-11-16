using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public int maxHealth = 100;
   public int health;

   public GameObject deathEffect;
   public HealthBar HealthBar;


    void Start()
    {
        health = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

   public void TakeDamage (int damage)
   {
    health -= damage;

    if (health <= 0)
    {
        Die();
    }
        HealthBar.SetHealth(health);
   }

   void Die ()
   {
    Instantiate(deathEffect, transform.position, Quaternion.identity);
    Destroy(gameObject);
   }
}
