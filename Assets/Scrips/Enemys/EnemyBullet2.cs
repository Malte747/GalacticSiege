using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{
    
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float lifeTime;
    public int damage;
    private bool hasDealtDamage = false;
     public float damageCooldown = 1.0f;
     public WinGame wingame;

    

    void Start()
    {
         rb.velocity = transform.right * speed; 
         Invoke("DestroyProjectile", lifeTime);
         wingame = GameObject.Find("GM").GetComponent<WinGame>();
         
    }

void Update()
{
    
        if(wingame != null && wingame.GameOver)
        {
            
            DestroyProjectileFast();
        }
}
   
    
     void OnTriggerEnter2D (Collider2D hitInfo) 
    {  
    	FindObjectOfType<AudioManager>().Play("AlienBullet2");
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

     private void ResetDamageCooldown()
    {
        
        hasDealtDamage = false; // Erlaube erneut Schaden
    }

    void DestroyProjectile()
    {
        FindObjectOfType<AudioManager>().Play("AlienBullet2");
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void DestroyProjectileFast()
    {
       Destroy(gameObject); 
    }
    

}
