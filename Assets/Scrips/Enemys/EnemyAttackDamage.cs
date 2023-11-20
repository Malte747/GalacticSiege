using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDamage : MonoBehaviour
{
    public int damage;
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
       

       
    }
}
