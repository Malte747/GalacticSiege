using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   public int maxHealth = 100;
   public int health;

   public GameObject deathEffect;
   public HealthBar HealthBar;
   public GameObject drop;

   

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

    int randomNumber = Random.Range(1, 101);
    if(randomNumber <= 100)
    {
        Instantiate(drop, transform.position, Quaternion.identity);
        Debug.Log("1");
    }
    }
        HealthBar.SetHealth(health);
   }

   void Die ()
   {
    
    Instantiate(deathEffect, transform.position, Quaternion.identity);
    Destroy(gameObject);
   }

   
}

