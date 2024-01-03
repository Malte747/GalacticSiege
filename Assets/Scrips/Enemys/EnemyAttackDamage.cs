using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDamage : MonoBehaviour
{
    public int damage;
    private bool hasDealtDamage = false;
     public float damageCooldown = 1.0f;
     Monster4Sound Monster4Sound;
     Monster1Hit Monster1Hit;


     void Start()
     {
        Monster4Sound = GetComponent<Monster4Sound>();
        Monster1Hit = GetComponent<Monster1Hit>();
     }
  void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        
        
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

         AllieHealth alliehealth = hitInfo.GetComponent<AllieHealth>();
        if (alliehealth != null && !hasDealtDamage)
        {
             hasDealtDamage = true;
            Invoke("ResetDamageCooldown", damageCooldown);
            alliehealth.TakeDamage(damage);
           
        }

        if(Monster4Sound != null)
        {
        Monster4Sound.Hit();
        }
        else if(Monster1Hit != null)
        {
        Monster1Hit.Hit();
        }
        else return;




    }
        private void ResetDamageCooldown()
    {
        hasDealtDamage = false; // Erlaube erneut Schaden
    }

       
   
}
