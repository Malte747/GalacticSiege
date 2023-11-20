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
        PlayerHealth health = hitInfo.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        CityHallHealth Leben = hitInfo.GetComponent<CityHallHealth>();
        if (Leben != null)
        {
            Leben.TakeDamage(damage);
        }
       

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }


    void DestroyProjectile()
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    

}
