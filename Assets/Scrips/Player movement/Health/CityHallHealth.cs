using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityHallHealth : MonoBehaviour
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
            SceneManager.LoadSceneAsync(1);
        }
        HealthBar.SetHealth(health);
    }
}
