using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AllieHealth : MonoBehaviour
{
   public int maxHealth = 100;
   public int health;

   public GameObject deathEffect;
   public HealthBar HealthBar;

  
   public bool Dead = false;
   

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
        Dead = true;
        Destroy(gameObject, 2f);
        HealthBar.SetHealth(health);
   }

   
}
}


