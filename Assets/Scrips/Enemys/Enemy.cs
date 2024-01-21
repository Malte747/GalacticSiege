using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   public int maxHealth = 100;
   public int health;

   public GameObject deathEffect;
   public HealthBar HealthBar;
   public GameObject drop;
   public float ultpoints = 4f;
   private float yOffset = 1f;
   UltBar ultbar;
   

    void Start()
    {
        health = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
        ultbar = GameObject.Find("GM").GetComponent<UltBar>();
    }
    
   public void TakeDamage (int damage)
   {
    health -= damage;

    if (health <= 0)
    {
        Die();

    int randomNumber = Random.Range(1, 101);
    if(randomNumber <= 10)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
         Instantiate(drop, spawnPosition, Quaternion.identity);
    }
    }
        HealthBar.SetHealth(health);
   }

   void Die ()
   {
    if(ultbar != null)
    {
    ultbar.PointsAdd(ultpoints);
    }
    Instantiate(deathEffect, transform.position, Quaternion.identity);
    Destroy(gameObject);
   }

   
}

