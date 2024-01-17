using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float lifeTime;
    public int damage;
    private float increaseRate = 1f;
    private float baseValue = 2f;

    private bool hasDealtDamage = false;
     public float damageCooldown = 0.1f;

    public UfoDeath ufolebt;



    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        FindObjectOfType<AudioManager>().Play("LaserBeam");
        ufolebt = GameObject.Find("Ufo(Clone)").GetComponent<UfoDeath>();
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
        speed *= Mathf.Pow(baseValue, increaseRate * Time.deltaTime);

        if(ufolebt != null && ufolebt.todlaser)
        {
            
            DestroyBullet();
        }

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        PlayerHealth health = hitInfo.GetComponent<PlayerHealth>();
        if (health != null )
        {
            hasDealtDamage = true;
            Invoke("ResetDamageCooldown", damageCooldown);
            health.TakeDamage(damage);
        }

        CityHallHealth Leben = hitInfo.GetComponent<CityHallHealth>();
        if (Leben != null )
        {
            hasDealtDamage = true;
            Invoke("ResetDamageCooldown", damageCooldown);
            Leben.TakeDamage(damage);
        }

        AllieHealth allieHealth = hitInfo.GetComponent<AllieHealth>();
        if (allieHealth != null )
        {
            hasDealtDamage = true;
            Invoke("ResetDamageCooldown", damageCooldown);
            allieHealth.TakeDamage(damage + 60);
        }
    }

    private void ResetDamageCooldown()
    {
        
        hasDealtDamage = false; // Erlaube erneut Schaden
    }
    
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void DestroyProjectile()
    {
        
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

