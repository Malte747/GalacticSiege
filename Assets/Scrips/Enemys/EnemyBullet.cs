using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float lifeTime;
    public int damage;
    private float increaseRate = 1f;
    private float baseValue = 2f;
   
    private bool hasDealtDamage = false;
     public float damageCooldown = 1.0f;

    

    void Start()
    {
      
         Invoke("DestroyProjectile", lifeTime);
         
    }

void Update()
{
    rb.velocity = transform.right * speed; 
    speed *= Mathf.Pow(baseValue, increaseRate * Time.deltaTime);
}
   
    
     void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        FindObjectOfType<AudioManager>().Play("AlienBullet");
        PlayerHealth health = hitInfo.GetComponent<PlayerHealth>();
        if (health != null && !hasDealtDamage)
        {
            hasDealtDamage = true;
            Invoke("ResetDamageCooldown", damageCooldown);
            health.TakeDamage(damage);
         
        }

        CityHallHealth Leben = hitInfo.GetComponent<CityHallHealth>();
        if (Leben != null && !hasDealtDamage)
        {
            hasDealtDamage = true;
            Invoke("ResetDamageCooldown", damageCooldown);
            Leben.TakeDamage(damage);
        }
         AllieHealth allieHealth = hitInfo.GetComponent<AllieHealth>();
        if (allieHealth != null && !hasDealtDamage)
        {
            hasDealtDamage = true;
            Invoke("ResetDamageCooldown", damageCooldown);
            allieHealth.TakeDamage(damage);
        }
       

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

     private void ResetDamageCooldown()
    {
        
        hasDealtDamage = false; // Erlaube erneut Schaden
    }

    void DestroyProjectile()
    {
        FindObjectOfType<AudioManager>().Play("AlienBullet");
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    

}
