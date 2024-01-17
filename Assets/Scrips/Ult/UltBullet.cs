using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltBullet : MonoBehaviour
{

    public int damage = 60;
    public Rigidbody2D rb;
    public GameObject impactEffect;
  public float speed = 10f;
   private Animator anim;
   

void Start()
    {
      anim = GetComponent<Animator>();
      rb.velocity = transform.right * speed; 
     rb.gravityScale = 1f;
     rb.AddForce(Vector2.down * 1f, ForceMode2D.Impulse);
     anim.SetTrigger("Rotation");
    }


   void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        UfoDeath ufodeath = hitInfo.GetComponent<UfoDeath>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); 
        }
        else if(ufodeath != null)
        {        
            ufodeath.TakeDamage(damage);
        }
        

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
        
    }
}
