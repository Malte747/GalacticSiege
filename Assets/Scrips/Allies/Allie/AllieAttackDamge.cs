using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllieAttackDamge : MonoBehaviour
{
    public int damage;
    private bool hasDealtDamage = false;
     public float damageCooldown = 1.0f;
  void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        Enemy health = hitInfo.GetComponent<Enemy>();
        if (health != null && !hasDealtDamage)
        {
            hasDealtDamage = true;
            Invoke("ResetDamageCooldown", damageCooldown);
            health.TakeDamage(damage);
       
        }

       
    }

     private void ResetDamageCooldown()
    {
        hasDealtDamage = false; // Erlaube erneut Schaden
    }
}
