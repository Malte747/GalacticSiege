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
        Instantiate(drop, transform.position, Quaternion.identity);
    }
    }
        HealthBar.SetHealth(health);
   }

   void Die ()
   {
    ultbar.PointsAdd(ultpoints);
    Instantiate(deathEffect, transform.position, Quaternion.identity);
    Destroy(gameObject);
   }

   
}

