using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float lifeTime;

     private bool hasDealtDamage = false;
     public float damageCooldown = 1.0f;


    

    void Start()
    {
      rb.velocity = transform.right * speed; 
         Invoke("DestroyProjectile", lifeTime);
         
    }


    void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        UfoDeath ufodeath = hitInfo.GetComponent<UfoDeath>();
        if (enemy != null && !hasDealtDamage)
        {
            hasDealtDamage = true;
            Invoke("ResetDamageCooldown", damageCooldown);
            enemy.TakeDamage(damage);
            
         
        }
        else if(ufodeath != null && !hasDealtDamage)
        {        
            hasDealtDamage = true;
            Invoke("ResetDamageCooldown", damageCooldown);
            ufodeath.TakeDamage(damage);
        }
        FindObjectOfType<AudioManager>().Play("PlayerBullet");

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    private void ResetDamageCooldown()
    {
        
        hasDealtDamage = false; // Erlaube erneut Schaden
    }


    void DestroyProjectile()
    {
        FindObjectOfType<AudioManager>().Play("PlayerBullet");
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    

}
