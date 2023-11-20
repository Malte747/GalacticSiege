using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public HealthBar HealthBar;

    
    void Start()
    {
        health = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

  
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        HealthBar.SetHealth(health);
    }

      public void Heal(int healing)
    {
        health += healing;
         if(health >= 100)
        {
            HealthBar.SetMaxHealth(maxHealth);
        }
        HealthBar.SetHealth(health);
    }
}
