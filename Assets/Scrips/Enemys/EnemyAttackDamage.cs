using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDamage : MonoBehaviour
{
    public int damage;
    private bool hasDealtDamage = false;
     public float damageCooldown = 1.0f;
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
  

    }
        private void ResetDamageCooldown()
    {
        hasDealtDamage = false; // Erlaube erneut Schaden
    }

       
   
}
